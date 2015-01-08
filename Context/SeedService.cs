using System;
using System.Collections.Generic;
using Models.EntityModels;

namespace Context
{
    public class SeedService
    {
        private readonly Random rnd = new Random(); 
        private readonly List<string> _workerNameList;
        private readonly List<string> _workerPhoneList;

        private readonly List<string> _adLocationList;

        private readonly List<string> _adAreaList;

        private readonly List<int> _adStoreyList;

        private readonly List<string> _adTechnicalList;

        private readonly List<int> _adRoomsList;

        private readonly List<string> _adHeatingList;

        private readonly List<string> _adRentList;

        private readonly List<string> _adOwnershipList;

        private readonly List<string> _adPricePerList;

        private readonly List<string> _adTitleList;

        private readonly List<string> _adDescriptionList;

        private readonly List<string> _adCityList;

        private readonly List<string> _adPriceList;

        public SeedService()
        {
            _workerNameList = new List<string>()
            {
                "Mateusz", "Mikołaj", "Wojciech", "Aleksander", "Aleksandra", "Daria"
            };

            _workerPhoneList = new List<string>()
            {
                "12321333", "45345345", "345345345345", "345345345","345345345"
            };

            _adLocationList = new List<string>()
            {
                "Śródmieście", "Psie Pole", "Zakrzów", "Pawłowice", "Sołtysowice", "Bielany"
            };

            _adAreaList = new List<string>()
            {
                "120m2",
                "110m2",
                "36m2",
                "164m2",
                "283m2",
                "11m2"
            };

            _adStoreyList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7
            };

            _adTechnicalList = new List<string>()
            {
                "Do remontu",
                "Do zamieszkania",
                "Do wymiany instalacja elektryczna",
                "Do remontu instalacja gazowa",
                "Do naprawy hydraulika"
            };

            _adRoomsList = new List<int>()
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8
            };

            _adHeatingList = new List<string>()
            {
                "gazowe", "elektryczne", "centralne", "kaflowe"
            };

            _adRentList = new List<string>()
            {
                "1500zł / miesiąc", "1280zł / miesiąc", "1777 / miesiące", "3205 / miesiąc"
            };

            _adOwnershipList = new List<string>()
            {
                "własnościowe", "spółdzielcze", "spółdzielcze własnościowe", "komunalne"
            };

            _adPricePerList = new List<string>()
            {
                "120zł / m2", "110zł / m2", "300zł / m2", "140zł / m2", "180zł / m2 "
            };

            _adTitleList = new List<string>()
            {
                "Ładne czteropokojowe", "Trzypokojowe przy kiepury", "Dom do remontu", "Mieszkanie w miłej okolicy", "Dom do wynajęcia na śródmieściu", "Słoneczne dwa pokoje", "M1 w kamienicy do remontu", "Kawalerka", "Mieszkanie w centrum na gabinety lub biura"
            };

            _adDescriptionList = new List<string>()
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum eleifend ornare pharetra. Nam quam lectus, tristique eget ligula a, euismod semper lectus. Mauris lobortis, orci nec blandit blandit, odio orci hendrerit leo, a iaculis urna risus id eros. Aliquam ac lectus eu nunc egestas scelerisque dignissim id quam. Aenean justo turpis, suscipit eget condimentum eu, posuere sed lorem. Phasellus auctor, quam eget fermentum dapibus, ipsum odio semper odio, in cursus leo magna vitae nibh. Pellentesque a odio et dui consequat venenatis quis quis tellus. Mauris in dui lacus. Aenean iaculis magna in feugiat placerat. Fusce ornare eros enim, nec elementum turpis pretium ut. Praesent posuere massa eu rhoncus mollis. Ut condimentum turpis sit amet lacus bibendum, id scelerisque neque accumsan. Vivamus iaculis quis purus quis vehicula. Sed diam massa, hendrerit non iaculis ut, laoreet id neque. Duis purus elit, placerat nec consectetur at, facilisis sed risus. Vivamus ac mauris vulputate, tincidunt metus sit amet, viverra quam.",
                "Curabitur posuere, quam ac feugiat convallis, diam dui tincidunt arcu, ut eleifend est eros a risus. Quisque sapien mauris, posuere eget diam a, pellentesque volutpat mi. Vivamus dignissim, purus ac congue lobortis, lectus ex cursus felis, sed efficitur ex urna nec dolor. Donec ullamcorper sapien ut ex consectetur, sit amet faucibus purus faucibus. Ut porttitor, enim et semper porttitor, eros magna posuere mi, ut vulputate mauris lorem ac nibh. Aliquam commodo tincidunt nibh, vitae efficitur risus pharetra in. Ut id tristique augue.",
                "Fusce ornare, nisi non dictum ultricies, leo justo semper orci, ac rhoncus odio ligula id mauris. Integer a risus ut purus gravida consectetur. Donec maximus quis sapien non tempor. Sed tincidunt augue et nulla bibendum scelerisque. Aliquam ac erat tortor. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Duis dignissim erat augue, vel vehicula nulla sagittis ac. Vivamus pharetra laoreet tellus, non lobortis justo. Integer a sapien euismod, scelerisque urna vitae, vehicula nibh. Phasellus id malesuada lacus. Donec risus sem, vestibulum id aliquet at, bibendum in massa. Maecenas posuere, diam porttitor viverra dictum, mi mi auctor lectus, et laoreet augue elit vulputate velit.",
                "Praesent nec sollicitudin nisl, sed mattis lacus. Vivamus dignissim nisl at viverra pulvinar. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Donec egestas faucibus condimentum. Integer in tincidunt mi. Phasellus maximus gravida volutpat. Donec non dignissim enim, vel lobortis dolor. Nam a tempus odio. Donec finibus risus est. Ut risus magna, cursus cursus sapien quis, suscipit facilisis nisi. Fusce egestas fringilla nunc congue fringilla. In vitae nisl at neque aliquet dignissim. Nunc iaculis maximus metus in feugiat. Mauris justo dolor, mattis eu consequat a, congue ac enim. Duis non feugiat tortor. Duis sagittis urna in est tincidunt, a tristique erat vestibulum.",
                "Pellentesque venenatis eu leo non imperdiet. Vivamus id urna et quam ultricies mollis ut vel leo. Aliquam sapien velit, blandit quis luctus vel, aliquet sit amet leo. Donec feugiat est nec quam ultrices condimentum. Praesent viverra elit non mauris mollis iaculis. Vivamus id tellus condimentum risus dictum ornare. Fusce maximus pellentesque odio sit amet lacinia. Nulla varius a mauris quis dapibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed tortor urna, gravida sed quam vitae, auctor rutrum purus. Maecenas vitae dui nec tortor consectetur porttitor vel a sapien.",
                "Cras metus libero, hendrerit vel eleifend in, tempor vitae elit. Donec vestibulum massa neque, ut dapibus dolor posuere hendrerit. Suspendisse rutrum placerat ex vel volutpat. In quis consequat neque. Ut sit amet dolor et felis fermentum fringilla. Nunc faucibus elit libero, id suscipit arcu imperdiet suscipit. Nulla facilisi. Nullam tristique quam eu tempor iaculis. Sed auctor nec nisl ut posuere. Nulla in gravida nisi, eu congue dolor. Curabitur vitae tortor consequat dui gravida pellentesque eu eget ligula. Proin aliquam augue vitae sollicitudin tincidunt. Mauris non eros finibus, sollicitudin leo dapibus, bibendum ante.",
                "Curabitur condimentum lobortis felis at tristique. Cras eget dolor diam. Praesent dolor leo, blandit ut fringilla eu, porta at ipsum. Donec varius imperdiet accumsan. Nulla arcu arcu, varius ac ultricies a, fermentum aliquam velit. Etiam pharetra vehicula ante id vehicula. Integer eu nibh lorem. Mauris nec felis gravida, sodales ante sed, facilisis ipsum. Donec eget arcu sit amet sapien viverra dictum eget eget felis. Donec maximus, nibh ut pharetra sagittis, urna turpis hendrerit dui, et fermentum turpis enim ac ipsum. Maecenas ut aliquam tellus.",
                "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Pellentesque luctus elementum eros, lobortis condimentum ligula varius quis. In convallis convallis lorem non ullamcorper. Praesent molestie ipsum volutpat congue semper. Etiam sed molestie lectus. Suspendisse eu leo massa. Quisque eget tellus non orci mollis placerat. Nulla tristique gravida hendrerit. Morbi euismod nibh eu nisl vehicula porttitor. Fusce nulla sapien, porttitor eget suscipit a, malesuada et enim.",
                "Phasellus congue velit quis ante lobortis, ut interdum leo blandit. In vitae erat felis. Proin sit amet porta nisi. Mauris risus nisi, efficitur sit amet lacus a, mattis sagittis eros. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec non posuere lorem. Sed odio purus, egestas eget cursus eget, suscipit ut sapien. Praesent ut nulla porta, congue lacus non, ornare erat. Nullam lectus sem, rutrum nec odio sed, sodales hendrerit odio. Vivamus ornare nulla metus, ac venenatis magna molestie nec. Quisque eu orci ex. Quisque et lacinia ex. Donec consectetur elit quis nunc elementum, eu pellentesque lorem feugiat.",
                "Morbi scelerisque arcu dignissim nulla hendrerit fermentum non vel arcu. Donec velit nisi, accumsan non est quis, blandit lobortis neque. Maecenas eleifend vehicula hendrerit. Quisque id enim sed massa consectetur tempor quis eget mi. Donec ut scelerisque augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris ultricies viverra dignissim. Praesent fringilla accumsan velit, non ultrices ante imperdiet non. Pellentesque ac lorem dolor. Curabitur varius libero quis posuere tincidunt. Suspendisse euismod iaculis arcu, eget feugiat dolor faucibus ut. Integer volutpat suscipit volutpat. Curabitur nec massa commodo, elementum erat eu, tristique sem. Nunc luctus leo sit amet ante mattis, ut auctor ante volutpat. Suspendisse ac libero maximus, sollicitudin dolor ac, pharetra risus. Maecenas massa urna, ultrices et est sed, blandit tristique quam."
            };

            _adCityList = new List<string>()
            {
                "Wrocław",
                "Trzebnica",
                "Wołów",
                "Warszawa",
                "Poznań",
                "Pasry",
                "Kryniczno",
                "Oleśnica"
            };

            _adPriceList = new List<string>()
            {
                "140 000zł", "250 000zł", "190 000zł", "550 000zł", "123 000zł", "338 000zł", "1 000 000zł", "2 540 233zł"
            };
        }

        public string GetRandom(List<string> list)
        {
            return list[rnd.Next(list.Count)];
        }

        public int GetRandomInt(List<int> list)
        {
            return list[rnd.Next(list.Count)];
        }

        public Worker GetWorker()
        {
            var worker = new Worker()
            {
                FirstName = GetRandom(_workerNameList),
                LastName = GetRandom(_workerNameList),
                Email = String.Format("{0}_{1}@gmail.com", GetRandom(_workerNameList), GetRandom(_workerNameList)),
                PhoneFirst = GetRandom(_workerPhoneList),
                PhoneSecond = GetRandom(_workerPhoneList),
                HasPhoto = false,
            };

            return worker;
        }

        public Flat GetFlat()
        {
            var flat = new Flat()
            {
                Area = GetRandom(_adAreaList),
                City = GetRandom(_adCityList),
                Price = GetRandom(_adPriceList),
                Description = GetRandom(_adDescriptionList),
                Details = GetRandom(_adDescriptionList),
                Title = GetRandom(_adTitleList),
                Heating = GetRandom(_adHeatingList),
                Location = GetRandom(_adLocationList),
                Ownership = GetRandom(_adOwnershipList),
                PricePerMeter = GetRandom(_adPricePerList),
                Rooms = GetRandomInt(_adRoomsList),
                Storey = GetRandomInt(_adStoreyList),
                Rent =  GetRandom(_adRentList),
                ToLet = (rnd.Next(10)%2==0),
                Visible = true,
                TechnicalCondition = GetRandom(_adTechnicalList),
                
            };

            return flat;
        }

        public House GetHouse()
        {
            var house = new House()
            {
                UsableArea = GetRandom(_adAreaList),
                City = GetRandom(_adCityList),
                Price = GetRandom(_adPriceList),
                Description = GetRandom(_adDescriptionList),
                Details = GetRandom(_adDescriptionList),
                Title = GetRandom(_adTitleList),
                Heating = GetRandom(_adHeatingList),
                Location = GetRandom(_adLocationList),
                Ownership = GetRandom(_adOwnershipList),
                PricePerMeter = GetRandom(_adPricePerList),
                Rooms = GetRandomInt(_adRoomsList),
                LandArea = GetRandom(_adAreaList),
                Rent = GetRandom(_adRentList),
                ToLet = (rnd.Next(10)%2 == 0),
                Visible = true,
                TechnicalCondition = GetRandom(_adTechnicalList),
            };
            return house;
        }

        public Land GetLand()
        {
            var land = new Land()
            {
                City = GetRandom(_adCityList),
                Price = GetRandom(_adPriceList),
                Description = GetRandom(_adDescriptionList),
                Details = GetRandom(_adDescriptionList),
                Title = GetRandom(_adTitleList),
                Location = GetRandom(_adLocationList),
                Ownership = GetRandom(_adOwnershipList),
                Visible = true,
            };

            return land;
        }
    }

    
}