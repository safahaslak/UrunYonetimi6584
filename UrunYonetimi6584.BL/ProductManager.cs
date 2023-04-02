using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace UrunYonetimi6584.BL
{
    public class ProductManager : Repository<UrunYonetim6584.Entities.Product> // repository e product class ını gönderdik böylece ProductManager'ı kullandığımızda repository deki tüm metodlar product class ı için çalışacak.
    {
    }
}
