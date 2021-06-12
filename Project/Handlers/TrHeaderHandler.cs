using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Factory;
using Project.Repositories;
using Project.Models;

namespace Project.Handlers
{
    public class TrHeaderHandler
    {
        readonly TrHeaderRepository TrHeaderRepository = new TrHeaderRepository();
        readonly TrHeaderFactory TrHeaderFactory = new TrHeaderFactory();

        public List<TrHeader> ReadAll()
        {
            List<TrHeader> result = TrHeaderRepository.ReadAll();
            return result;
        }
        public TrHeader ReadOneByID(Guid ID)
        {
            TrHeader result = TrHeaderRepository.ReadOneByID(ID);
            return result;
        }
        public TrHeader CreateOne(Guid memberID, Guid employeeID, DateTime transactionDate, decimal discountPercentage)
        {
            TrHeader currentTrHeader = TrHeaderFactory.Create(Guid.NewGuid(), memberID, employeeID, transactionDate, discountPercentage);

            TrHeader result = TrHeaderRepository.CreateOne(currentTrHeader);

            return result;
        }
        public TrHeader UpdateOneByID(Guid ID, Guid memberID, Guid employeeID, DateTime transactionDate, decimal discountPercentage)
        {
            TrHeader currentTrHeader = TrHeaderFactory.Create(Guid.NewGuid(), memberID, employeeID, transactionDate, discountPercentage);

            TrHeader result = TrHeaderRepository.UpdateOneByID(ID, currentTrHeader);

            return result;
        }
        public TrHeader DeleteOneByID(Guid ID)
        {
            TrHeader result = TrHeaderRepository.DeleteOneByID(ID);
            return result;
        }
    }
}