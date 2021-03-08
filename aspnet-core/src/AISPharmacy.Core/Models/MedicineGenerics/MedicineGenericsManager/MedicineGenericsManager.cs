﻿using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.MedicineGenerics.MedicineGenericsManager
{
    class MedicineGenericsManager : DomainService, IMedicineGenericsManager
    {
        private readonly IRepository<MedicineGeneric, int> repository;

        public MedicineGenericsManager(IRepository<MedicineGeneric, int> repository)
        {
            this.repository = repository;
        }

        public async Task<MedicineGeneric> Create(MedicineGeneric medicineGenerics)
        {
            var newGeneric = repository.FirstOrDefault(x => x.Name.Trim().Replace(" ", "").ToLower() == medicineGenerics.Name.Trim().Replace(" ", "").ToLower());
            if (newGeneric != null)
            {
                throw new UserFriendlyException("Generic Already Exist! Try Update");
            }
            else
            {
                return await this.repository.InsertAsync(medicineGenerics);
            }
        }

        public void Delete(int id)
        {
            var foundGeneric = this.repository.FirstOrDefault(x => x.Id == id);
            if (foundGeneric != null)
            {
                this.repository.Delete(foundGeneric);
            }
            else
            {
                throw new UserFriendlyException("Generic Does Not Found. Try Adding First!");
            }
        }

        public List<MedicineGeneric> GetAllMedicineGenerics(string keyword)
        {
            if (keyword == null)
            {
                var generics = repository.GetAll().ToList();

                return generics;
            }
            else
            {
                var generics = repository.GetAll()
                    .Where (x => x.Name.Contains("keyword"))
                    .ToList();

                return generics;
            }
        }

        public MedicineGeneric GetMedicineGenerics(int id)
        {
            var foundGeneric = this.repository.FirstOrDefault(x => x.Id == id);
            if (foundGeneric != null)
            {
                return foundGeneric;
            }
            else
            {
                throw new UserFriendlyException("Medicine Generic Not Found!");
            }
        }

        public void Update(MedicineGeneric medicineGenerics)
        {
            var foundGeneric = this.repository.FirstOrDefault(x => x.Id == medicineGenerics.Id);
            if (foundGeneric != null)
            {
                ObjectMapper.Map(medicineGenerics, foundGeneric);
            }
            else
            {
                throw new UserFriendlyException("Medicine Generic Not Found!");
            }
        }
    }
}
