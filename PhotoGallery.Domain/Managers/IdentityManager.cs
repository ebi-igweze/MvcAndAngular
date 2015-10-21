using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Domain.Managers
{
    public class IdentityManager
    {
        public IDataRepository _db;
        public IdentityManager(IDataRepository dataRepository) { _db = dataRepository; }
        
    }
}
