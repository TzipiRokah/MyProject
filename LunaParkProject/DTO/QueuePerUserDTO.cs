using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QueuePerUserDTO
    {
        public int QueuePerUserId { get; set; }
        public int QueueId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> CountTickets { get; set; }

        public QueuePerUserDTO(QueuePerUserDTO qDTO)
        {
            QueuePerUserId = qDTO.QueuePerUserId;
            QueueId = qDTO.QueueId;
            UserId = qDTO.UserId;
            CountTickets = qDTO.CountTickets;
        }

        public QueuePerUserDTO(QueuePerUser qDB)
        {
            QueuePerUserId = qDB.QueuePerUserId;
            QueueId = qDB.QueueId;
            UserId = qDB.UserId;
            CountTickets = qDB.CountTickets;
        }

        public QueuePerUserDTO()
        {

        }

        public static List<QueuePerUserDTO> ConvertQueuePerUserToDTO(List<QueuePerUser> list)
        {
            var x = from qDTO in list
                    select new QueuePerUserDTO(qDTO);
            return x.ToList();
        }

        public static QueuePerUser ConvertDTOToQueuePerUser(QueuePerUserDTO qDTO)
        {
            QueuePerUser qDB = new QueuePerUser()
            {

                QueuePerUserId = qDTO.QueuePerUserId,
                QueueId = qDTO.QueueId,
                UserId = qDTO.UserId,
                CountTickets = qDTO.CountTickets
            };
            if (qDTO != null)
                return qDB;
            else
                return null;
        }
    }
}
