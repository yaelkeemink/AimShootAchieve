﻿using _001_Domain.Entities;
using _001_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.Services.NonPublicServices
{
    public class LijstService
        : ILijstService
    {
        private readonly IRepository<Lijst> _lijstRepo;
        private readonly IRepository<LijstItem> _lijstItemRepo;

        public LijstService(IRepository<Lijst> lijstRepo, IRepository<LijstItem> lijstItemRepo)
        {
            _lijstRepo = lijstRepo;
            _lijstItemRepo = lijstItemRepo;
        }
        public void Add(Lijst item)
        {
            _lijstRepo.Insert(item);
        }

        public void AddItem(LijstItem item)
        {
            var lijst = Get(item.LijstId, item.UserId);
            item.UserId = lijst.UserId;
            item.Id = 0;
            lijst.Items.Add(item);
            Update(lijst);
        }

        public void Delete(int id, string userId)
        {
            var toDelete = _lijstRepo.Find(id, userId);
            _lijstRepo.Delete(toDelete);
        }

        public Lijst Get(int id, string userId)
        {
            return _lijstRepo.Find(id, userId);
        }

        public IEnumerable<Lijst> GetAll(string userId)
        {
            return _lijstRepo.FindAll(userId)
                .OrderBy(a => a.Naam)
                .ThenBy(a => a.Id);
        }

        public int RemoveItem(int itemId, string userId)
        {
            var item = _lijstItemRepo.Find(itemId, userId);
            var lijst = _lijstRepo.Find(item.LijstId, userId);
            lijst.Items.Remove(item);
            _lijstRepo.Update(lijst);
            return lijst.Id;
        }

        public void Update(Lijst item)
        {
            _lijstRepo.Update(item);
        }

        public void Dispose()
        {
            _lijstRepo?.Dispose();
            _lijstItemRepo?.Dispose();
        }
    }
}