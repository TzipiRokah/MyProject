using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DTO
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public Nullable<System.DateTime> MessageDateTime { get; set; }
        public string MessageDetails { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> AccessLevelId { get; set; }


        public MessageDTO(MessageDTO mDTO)
        {
            MessageId = mDTO.MessageId;
            MessageDateTime = mDTO.MessageDateTime;
            MessageDetails = mDTO.MessageDetails;
            EmployeeId = mDTO.EmployeeId;
            AttractionId = mDTO.AttractionId;
            UserId = mDTO.UserId;
            AccessLevelId = mDTO.AccessLevelId;
        }
        public MessageDTO(Message mDB)
        {
            MessageId = mDB.MessageId;
            MessageDateTime = mDB.MessageDateTime;
            MessageDetails = mDB.MessageDetails;
            EmployeeId = mDB.EmployeeId;
            AttractionId = mDB.AttractionId;
            UserId = mDB.UserId;
            AccessLevelId = mDB.AccessLevelId;
        }

        public MessageDTO()
        {
                
        }

        public static List<MessageDTO> ConvertMessageToDTO(List<Message> list)
        {
            var x = from mDTO in list
                    select new MessageDTO(mDTO);
            return x.ToList();
        }
        public static Message ConvertDTOToMessage(MessageDTO mDTO)
        {
            Message mDB = new Message()
            {
                MessageId = mDTO.MessageId,
                MessageDateTime = mDTO.MessageDateTime,
                MessageDetails = mDTO.MessageDetails,
                EmployeeId = mDTO.EmployeeId,
                AttractionId = mDTO.AttractionId,
                UserId = mDTO.UserId,
                AccessLevelId = mDTO.AccessLevelId
            };
            return mDB;
        }
    }
}
