namespace odev1.Models
{
    public class Repository{

        private static readonly List<Yazokul> _yazokul = new();

        static Repository(){
            _yazokul = new List<Yazokul>(){
                new Yazokul(){
                Id = 1,
                Title="Futbol Yaz Okulu",
                Description = "Kayseri Kadir Has Şehir Stadyumunda gerçekleşecek.",
                Image="1.jpg",
                isActive = true,
                isHome = true                    
                },
                new Yazokul(){
                Id = 2,
                Title="Basketbol Yaz Okulu",
                Description = "AHD Spor Tesislerinde gerçekleşecek.",
                Image="2.jpg",
                isActive = true,
                isHome = true 
                },
                new Yazokul(){
                Id = 3,
                Title="Voleybol Yaz Okulu",
                Description = "AHD Spor Tesislerinde gerçekleşecek.",
                Image="3.jpg",
                isActive = true,
                isHome = true 
                },
                new Yazokul(){
                Id = 4,
                Title="Tenis Yaz Okulu",
                Description = "Kapalı Tenis Kortu ve Spor Merkezi gerçekleşecek.",
                Image="4.jpg",
                isActive = true,
                isHome = true 
                },
                new Yazokul(){
                Id = 5,
                Title="Yüzme Yaz Okulu",
                Description = "Kümer Spor Merkezi ve Yüzme Havuzunda gerçekleşecek.",
                Image="5.jpg",
                isActive = true,
                isHome = true 
            },
            new Yazokul(){
                Id = 6,
                Title="Tekvando Yaz Okulu",
                Description = " Necip Fazıl Kısakürek Sosyal Tesislerinde gerçekleşecek.",
                Image="6.jpg",
                isActive = true,
                isHome = true 
            },
            new Yazokul(){
                Id = 7,
                Title="Kickboks Yaz Okulu",
                Description = " Necip Fazıl Kısakürek Sosyal Tesislerinde gerçekleşecek.",
                Image="7.jpg",
                isActive = true,
                isHome = true 
            }
        };
    }


        public static List<Yazokul> Yazokuls{
            get{
                return _yazokul;
            }
        }

        public static Yazokul? GetById(int? id){
            return _yazokul.FirstOrDefault(c => c.Id == id);
        }
    }
}