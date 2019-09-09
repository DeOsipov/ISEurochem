using System.Collections.Generic;

namespace test
{
    public class DocumentType
    {
        internal int id;
        internal string name;                //TODO main/must have
        internal int parentId;
        internal string acronym;
        internal string note;
        internal string loadingClass;
        internal int imageId;
        internal int state;                  //TODO 0 -> active, 250 -> not active
        internal string modificationDate;
        internal string modificationUserId;
        internal List<DocumentType> child = new List<DocumentType>();
    }
}