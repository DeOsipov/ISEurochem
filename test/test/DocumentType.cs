using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class DocumentType
    {
        public string id;
        public string name;                //TODO main/must have
        public string parentId;
        public string acronym;
        public string note;
        public string loadingClass;     //TODO if null -> dont load
        public string imageId;
        public string state;                  //TODO 0 -> active, 250 -> not active
        public string modificationDate;
        public string modificationUserId;
    }
}
