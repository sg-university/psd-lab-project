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
        public TrHeader CreateOne(TrHeader toCreateTrHeader)
        {
            TrHeader currentTrHeader = TrHeaderFactory.Create(Guid.NewGuid(), toCreateTrHeader.MemberID.GetValueOrDefault(), toCreateTrHeader.EmployeeID.GetValueOrDefault(), toCreateTrHeader.TransactionDate.GetValueOrDefault(), toCreateTrHeader.DiscountPercentage.GetValueOrDefault());

            TrHeader result = TrHeaderRepository.CreateOne(currentTrHeader);

            return result;
        }
        public TrHeader UpdateOneByID(Guid ID, TrHeader toUpdateTrHeader)
        {
            TrHeader currentTrHeader = TrHeaderFactory.Create(Guid.NewGuid(), toUpdateTrHeader.MemberID.GetValueOrDefault(), toUpdateTrHeader.EmployeeID.GetValueOrDefault(), toUpdateTrHeader.TransactionDate.GetValueOrDefault(), toUpdateTrHeader.DiscountPercentage.GetValueOrDefault());

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