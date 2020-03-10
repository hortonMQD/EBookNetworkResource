using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Model
{
    public class BookInfo
    {
        private String id;
        private String oldID;
        private String imageUrl;
        private String imageName;
        private String name;
        private String author;
        private String text;
        private String serialState;
        private String bookTypeID;
        private String bookTypeName;
        private String bookTypeIsTrue;
        private String fileUrl;
        private String fileSize;
        private String fileName;
        private String uploadUserID;
        private String uploadUserText;
        private String uploadTime;
        private String downloadCount;
        private String isTrue;
        private String isDelete;
        private String auditOpinion;
        private String isPass;
        private String Opinion;
        private String PersonalID;
        private String PersonalName;
        private String PersonalEmail;


        public BookInfo()
        {
            Id = IDUtils.GetGuid16String();
            AuditOpinion = IDUtils.GetGuid16String();
        }

        public string Id { get => id; set => id = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Text { get => text; set => text = value; }
        public string SerialState { get => serialState; set => serialState = value; }
        public string BookTypeID { get => bookTypeID; set => bookTypeID = value; }
        public string BookTypeName { get => bookTypeName; set => bookTypeName = value; }
        public string BookTypeIsTrue { get => bookTypeIsTrue; set => bookTypeIsTrue = value; }
        public string FileUrl { get => fileUrl; set => fileUrl = value; }
        public string FileSize { get => fileSize; set => fileSize = value; }
        public string UploadUserID { get => uploadUserID; set => uploadUserID = value; }
        public string UploadUserText { get => uploadUserText; set => uploadUserText = value; }
        public string UploadTime { get => uploadTime; set => uploadTime = value; }
        public string DownloadCount { get => downloadCount; set => downloadCount = value; }
        public string IsTrue { get => isTrue; set => isTrue = value; }
        public string AuditOpinion { get => auditOpinion; set => auditOpinion = value; }
        public string IsPass { get => isPass; set => isPass = value; }
        public string Opinion1 { get => Opinion; set => Opinion = value; }
        public string PersonalID1 { get => PersonalID; set => PersonalID = value; }
        public string PersonalName1 { get => PersonalName; set => PersonalName = value; }
        public string PersonalEmail1 { get => PersonalEmail; set => PersonalEmail = value; }
        public string ImageName { get => imageName; set => imageName = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string OldID { get => oldID; set => oldID = value; }
        public string IsDelete { get => isDelete; set => isDelete = value; }
    }
}
