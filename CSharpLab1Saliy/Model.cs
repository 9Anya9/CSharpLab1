using System;


namespace CSharpLab1Saliy
{
    internal class Model
    {
        private DateTime _birthday;
        internal bool Valid { get; private set; }
        internal string Age { get; private set; }
        internal string WestZodiac { get; private set; }
        internal string ChineseZodiac { get; private set; }

        internal Model()
        {
            _birthday = DateTime.Today;
        }

        internal DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                var today = DateTime.Today;
                var dyears = (today.Year - value.Year) - (today.DayOfYear >= _birthday.DayOfYear ? 0 : 1);
                var deltaDateTime = today - value;

                Valid = deltaDateTime.Days >= 0 && dyears <= 135;
                if (Valid)
                {
                    Age = dyears > 0 ? dyears + " year(s)" : deltaDateTime.Days + " day(s)";
                    ChineseZodiac = ChineseZodiaсs[(_birthday.Year + 8) % 12];

                    var month = _birthday.Month;
                    var day = _birthday.Day;
                    int westZodiacNum;
                    switch (month)
                    {
                        case 1:  //January
                            westZodiacNum = day <= 20 ? 9 : 10;
                            break;
                        case 2: //February
                            westZodiacNum = day <= 19 ? 10 : 11;
                            break;
                        case 3: //March
                            westZodiacNum = day <= 20 ? 11 : 0;
                            break;
                        case 4: //April
                            westZodiacNum = day <= 20 ? 0 : 1;
                            break;
                        case 5: //May
                            westZodiacNum = day <= 20 ? 1 : 2;
                            break;
                        case 6: //June
                            westZodiacNum = day <= 20 ? 2 : 3;
                            break;
                        case 7: //Jule
                            westZodiacNum = day <= 21 ? 3 : 4;
                            break;
                        case 8: //August
                            westZodiacNum = day <= 22 ? 4 : 5;
                            break;
                        case 9: //September
                            westZodiacNum = day <= 21 ? 5 : 6;
                            break;
                        case 10: //October
                            westZodiacNum = day <= 21 ? 6 : 7;
                            break;
                        case 11: //November
                            westZodiacNum = day <= 21 ? 7 : 8;
                            break;
                        case 12: //December
                            westZodiacNum = day <= 21 ? 8 : 9;
                            break;
                        default:
                            westZodiacNum = 0;
                            break;
                    }
                    WestZodiac = WesternZodiaсs[westZodiacNum];
                }
                else
                {
                    Age = WestZodiac = ChineseZodiac = "";
                }
            }
        }

        public bool IsBirthday
        {
            get
            {
                var today = DateTime.Today;
                return today.Month == _birthday.Month && today.Day == _birthday.Day;
            }
        }

        private static readonly string[] WesternZodiaсs = {
            "Ram",
            "Bull",
            "Twins",
            "Crab",
            "Lion",
            "Virgin",
            "Scales",
            "Scorpion",
            "Archer",
            "Mountain Sea-Goat",
            "Water Bearer",
            "Fish"
        };

        private static readonly string[] ChineseZodiaсs = {
            "Rat",
            "Ox",
            "Tiger",
            "Rabbit",
            "Dragon",
            "Snake",
            "Horse",
            "Goat",
            "Monkey",
            "Rooster",
            "Dog",
            "Pig"
        };
    }
}
