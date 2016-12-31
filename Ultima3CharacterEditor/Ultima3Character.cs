using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Ultima3CharacterEditor
{
        public static class Constants
        {
            public const int NumWeaponType = 16;
            public const int NumArmourType = 8;
            public const int MaxNumNameLetters = 14;
        }

        public enum SexType : Byte { MALE = (Byte)'M', FEMALE = (Byte)'F', OTHERS = (Byte)'O' }

        public enum WeaponType
        {
            HANDS, DAGGER, MACE, SLING, AXE, BOW, SWORD, TWO_H_SWORD,
            TWO_PLUS_AXE, TWO_PLUS_BOW, TWO_PLUS_SWORD, GLOVES,
            FOUR_PLUS_AXE, FOUR_PLUS_BOW, FOUR_PLUS_SWORD, EXOTIC
        }

        public enum ArmourType
        {
            SKIN, CLOTH, LEATHER, CHAIN,
            PLATE, TWO_PLUS_CHAIN, TWO_PLUS_PLATE, EXOTIC
        }

        public enum CharacterStatus : Byte { GOOD = (Byte)'G', POISONED = (Byte)'P', DEAD = (Byte)'D' }

        public enum RaceType : Byte
        {
            HUMAN = (Byte)'H',
            ELF = (Byte)'E',
            DWARF = (Byte)'D',
            BOBBIT = (Byte)'B',
            FUZZY = (Byte)'F',
        }

        public enum ProfessionType : Byte
        {
            FIGHTER = (Byte)'F', CLERIC = (Byte)'C', WIZARD = (Byte)'W', THIEF = (Byte)'T',
            PALADIN = (Byte)'P', BARBARIAN = (Byte)'B',  LARK= (Byte)'L', ILLUSIONIST=(Byte)'I',
            DRUID = (Byte)'D', ALCHEMIST = (Byte)'A', RANGER = (Byte)'R' 
        }

        public enum Marks : Byte { KINGS = 0x08, FIRE = 0x02, SNAKE = 0x04, FORCE = 0x01 };
        public enum Cards : Byte { LOVE = 0x10, SOL = 0x20, MOONS = 0x40, DEATH = 0x80 };

        public class U3Character
        {
            public static Dictionary<SexType, string> sexLabel = new Dictionary<SexType, string>() {
            {SexType.MALE, "Male"},
            {SexType.FEMALE, "Female"},
            {SexType.OTHERS, "Others"}};

            public static SexType[] sexArray = sexLabel.Keys.ToArray();

            public static Dictionary<CharacterStatus, string> statusLabel = new Dictionary<CharacterStatus, string>() {
            {CharacterStatus.GOOD, "Good"},
            {CharacterStatus.DEAD, "Dead"},
            {CharacterStatus.POISONED, "Poisoned"}};
        
            public static Dictionary<RaceType, string> raceLabel = new Dictionary<RaceType, string>() {
            {RaceType.BOBBIT, "Bobbit"},
            {RaceType.HUMAN, "Human"},
            {RaceType.FUZZY, "Fuzzy"},
            {RaceType.DWARF, "Dwarf"},
            {RaceType.ELF, "Elf"}};

            public static RaceType[] raceArray = raceLabel.Keys.ToArray();

            public static Dictionary<ProfessionType, string> professionLabel = new Dictionary<ProfessionType, string>() {
            {ProfessionType.WIZARD, "Wizard"},
            {ProfessionType.FIGHTER, "Fighter"},
            {ProfessionType.CLERIC, "Cleric"},
            {ProfessionType.PALADIN, "Paladin"},
            {ProfessionType.ALCHEMIST, "Alchemist"},
            {ProfessionType.BARBARIAN, "Barbarian"},
            {ProfessionType.RANGER, "Ranger" },
            {ProfessionType.THIEF, "Thief"},
            {ProfessionType.ILLUSIONIST, "Illusionist" },
            {ProfessionType.LARK, "Lark"},
            {ProfessionType.DRUID, "Druid" }
            };

             public static ProfessionType[] professionArray = professionLabel.Keys.ToArray();

        public static string[] weaponLabel = new string[] {
            "hands", "dagger", "mace", "sling", "axe", "bow", "sword", "two hands sword",
            "2+axe","2+bow", "2+sword", "gloves","4+axe", "4+bow", "4+sword", "exotic"};

            public static string[] armourLabel = new string[] {
            "skin", "cloth", "leather", "chain",
            "plate", "2+chain", "2+plate", "exotic"};
        private string name;
        private SexType sex;
        private RaceType race;
        private ProfessionType profession;

        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = (value.Length > 14) ? value.Substring(0, 14) : value;
            }
        }
        
        public SexType Sex {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        public RaceType Race {
            get
            {
                return race;
            }
            set
            {
                race = value;
            }
        }

        public ProfessionType Profession {
            get
            {
                return profession;
            }
            set
            {
                profession = value;
            }
        }

        public Byte Strength { get; set; }
        public Byte Dexterity { get; set; }
        public Byte Intelligence { get; set; }
        public Byte Wisdom { get; set; }

        public UInt16 HP { get; set; }
        public UInt16 MaxHP { get; set; }
        public UInt16 Experience { get; set; }
        public Byte Level { get; set; }

        public Byte Magic { get; set; }
        public Byte MaxMagic { get; set; }

        public CharacterStatus Status { get; set; }

        public Byte CardsMarks = 0;

        public UInt16 Gold { get; set; }
        public UInt16 Food { get; set; }
        public Byte Keys { get; set; }
        public Byte Gems { get; set; }
        public Byte Torches { get; set; }
        public Byte Powders { get; set; }

        private Byte x10;

        public ArmourType ArmourReadied;
        public WeaponType WeaponReadied;

        public Byte[] Armour;
        public Byte[] Weapons;

        public U3Character()
        {
            Name = "";
            x10 = 255;
            Sex = SexType.MALE;
            Race = RaceType.HUMAN;
            Profession = ProfessionType.FIGHTER;

            Strength = 0;
            Dexterity = 0;
            Intelligence = 0;
            Wisdom = 0;

            HP = 0;
            MaxHP = 150;
            Experience = 0;
            Level = 0;

            Magic = 0;
            MaxMagic = 0;
            Status = CharacterStatus.GOOD;

            Gold = 0;
            Food = 150;
            Keys = 0;
            Gems = 0;
            Torches = 0;
            Powders = 0;

            ArmourReadied = ArmourType.SKIN;
            WeaponReadied = WeaponType.HANDS;

            Armour = new Byte[Constants.NumArmourType];
            Weapons = new Byte[Constants.NumWeaponType];
        }

        public void print()
        {
            char[] charToTrim = { '\0' };
            string sout = "";
            sout += String.Format("Name:{0}\n", Name.Trim(charToTrim));

            sout += String.Format("Strength:{0}\n", Strength);
            sout += String.Format("Dexterity:{0}\n", Dexterity);
            sout += String.Format("Intelligence:{0}\n", Intelligence);
            sout += String.Format("Wisdom:{0}\n", Wisdom);

            sout += String.Format("Sex:{0}\n", sexLabel[Sex]);
            sout += String.Format("Race:{0}\n", raceLabel[Race]);
            sout += String.Format("Profession:{0}\n", professionLabel[Profession]);
            sout += String.Format("Magic:{0}\n", Magic);
            sout += String.Format("H.P.:{0}\n", HP);
            sout += String.Format("Max H.P.:{0}\n", MaxHP);
            sout += String.Format("Exp:{0}\n", Experience);
            sout += String.Format("Food:{0}\n", Food);
            sout += String.Format("Max Magic:{0}\n", MaxMagic);

            sout += String.Format("Gold:{0}\n", Gold);
            sout += String.Format("Keys:{0}\n", Keys);
            sout += String.Format("Gems:{0}\n", Gems);
            sout += String.Format("Torches:{0}\n", Torches);
            sout += String.Format("Powders:{0}\n", Powders);
            sout += "*** Armours ***\n";
            sout += String.Format("{0}{1}\n", armourLabel[0], ArmourReadied == ArmourType.SKIN ? "*" : "");
            for (int i = Constants.NumArmourType - 1; i >= 0; i--)
            {
                if (Armour[i] > 0)
                {
                    sout += String.Format("{0}[{1}]{2}\n", armourLabel[i], Armour[i], (int)ArmourReadied == i ? "*" : ""
                        );
                }

            }
            sout += "*** Weapons ***\n";
            sout += String.Format("{0}[2]{1}\n", weaponLabel[0], WeaponReadied == WeaponType.HANDS ? "*" : "");
            for (int i = Constants.NumWeaponType - 1; i >= 0; i--)
            {
                if (Weapons[i] > 0)
                {
                    sout += String.Format("{0}[{1}]{2}\n", weaponLabel[i], Weapons[i], (int)WeaponReadied == i ? "*" : ""
                        );
                }
            }
            sout += "*** Marks ***\n";
            if ((CardsMarks & (byte)Marks.KINGS) > 0) sout += "KINGS\n";
            if ((CardsMarks & (byte)Marks.FIRE) > 0) sout += "FIRE\n";
            if ((CardsMarks & (byte)Marks.SNAKE) > 0) sout += "SNAKE\n";
            if ((CardsMarks & (byte)Marks.FORCE) > 0) sout += "FORCE\n";
            sout += "*** Cards ***\n";
            if ((CardsMarks & (byte)Cards.LOVE) > 0) sout += "LOVE\n";
            if ((CardsMarks & (byte)Cards.SOL) > 0) sout += "SOL\n";
            if ((CardsMarks & (byte)Cards.MOONS) > 0) sout += "MOONS\n";
            if ((CardsMarks & (byte)Cards.DEATH) > 0) sout += "DEATH\n";

            Console.WriteLine(sout);
        }


        public bool readCharacterFromBinaryReader(BinaryReader reader)
        {
            //x00-x0d |Your character's name. See ASCII stipulations above.
            Char[] tempc;

            tempc = reader.ReadChars(Constants.MaxNumNameLetters);
            if (tempc[0] == 0)
            {
                Char[] tempd = reader.ReadChars(64 - Constants.MaxNumNameLetters);
                return false;
            }
            else
            {
                Name = new string(tempc, 0, Constants.MaxNumNameLetters);

                //x0e     |Special item byte--each bit toggles something different
                //        | 0x80 = Card of Death 0x08 = Mark of Kings
                //        | 0x40 = Card of Moons 0x04 = Mark of Snake
                //        | 0x20 = Card of Sol   0x02 = Mark of Fire
                //        | 0x10 = Card of Love  0x01 = Mark of Force
                CardsMarks = reader.ReadByte();
                //x0f     | Torches
                Torches = U3EditorUtil.read1Dec(reader);
                //x10     | Seems safe to change but unimportant overall
                x10 = reader.ReadByte();
                //x11     | Status: C7=good(letter G), C4=dead(D), D0=poison(P)
                Status = (CharacterStatus)reader.ReadByte();
                //x12     | Strength
                Strength = U3EditorUtil.read1Dec(reader);
                //x13     | Dexterity
                Dexterity = U3EditorUtil.read1Dec(reader);
                //x14     | Intelligence
                Intelligence = U3EditorUtil.read1Dec(reader);
                //x15     | Wisdom
                Wisdom = U3EditorUtil.read1Dec(reader);
                //x16     | race: [choices here]
                Race = (RaceType)reader.ReadByte();
                //x17     | profession
                Profession = (ProfessionType)reader.ReadByte();
                //x18     | gender: CD = M(male,) C6 = F(female)
                Sex = (SexType)reader.ReadByte();

                //x19     | magic points?
                Magic = U3EditorUtil.read1Dec(reader);
                //x1a-x1b | hit points
                HP = U3EditorUtil.read2Dec(reader);

                //x1c-x1d | maximum hit points
                MaxHP = U3EditorUtil.read2Dec(reader);
                //x1e-x1f | experience
                Experience = U3EditorUtil.TwoByteHex2Dec(reader.ReadUInt16());
                //x20-x21 | food
                Food = U3EditorUtil.read2Dec(reader);
                //x22     | max magic points????
                MaxMagic = U3EditorUtil.read1Dec(reader);
                //x23-x24 | gold
                Gold = U3EditorUtil.read2Dec(reader);
                //x25     | Gems
                Gems = U3EditorUtil.read1Dec(reader);
                //x26     | Keys
                Keys = U3EditorUtil.read1Dec(reader);
                //x27     | Powder
                Powders = U3EditorUtil.read1Dec(reader);
                //x28     | Armor readied[0 = skin 1 = cloth 2 = leather 3 = chain
                //        | 4 = plate 5 = +2 chain 6 = +2 plate 7 = exotic]
                ArmourReadied = (ArmourType)reader.ReadByte();

                for (int i = 1; i < Constants.NumArmourType; i++)
                    Armour[i] = U3EditorUtil.read1Dec(reader);

                //x29     | # of cloth owned [# of skin = 2 always]
                //x2a     | # of leather owned
                //x2b     | # of chain owned
                //x2c     | # of plate owned
                //x2d     | # of +2 chain owned
                //x2e     | # of +2 plate owned
                //x2f     | # of exotic owned

                WeaponReadied = (WeaponType)reader.ReadByte();
                for (int i = 1; i < Constants.NumWeaponType; i++)
                    Weapons[i] = U3EditorUtil.read1Dec(reader);
                //x30     | Weapon readied[0 = hands 1 = dagger 2 = mace 3 = sling
                //        | 4 = axe 5 = bow 6 = sword 7 = 2 - h sword 8 = +2 axe
                //        | 9 = +2 bow a = +2 sword b = gloves c = +4 axe d = +4 bow
                //        | e = +4 sword f = exotic]
                //x31     | # of dagger owned [# of hands = 2 always]
                //x32     | # of mace owned
                //x33     | # of sling owned
                //x34     | # of axe owned
                //x35     | # of bow owned
                //x36     | # of sword owned
                //x37     | # of 2 handed sword owned
                //x38     | # of +2 axe owned
                //x39     | # of +2 bow owned
                //x3a     | # of +2 sword owned
                //x3b     | # of gloves owned
                //x3c     | # of +4 axe owned
                //x3d     | # of +4 bow owned
                //x3e     | # of +4 sword owned
                //x3f     | # of exotic owned

                return true;
            }
        }




        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public void writeCharacterToBinaryWriter(BinaryWriter writer)
        {
            //x00-x0d |Your character's name. See ASCII stipulations above.
            //Char[] tempc;

            //tempc = reader.ReadChars(Constants.MaxNumNameLetters);
            //if (tempc[0] == 0)
            //{
            //    Char[] tempd = reader.ReadChars(64 - Constants.MaxNumNameLetters);
            //    return false;
            //}
            //else
            //{
            ////// Name = new string(tempc, 0, Constants.MaxNumNameLetters);

            byte[] namebuffer;
            namebuffer = new byte[Constants.MaxNumNameLetters];
            
            for (int ii = 0; ii < Constants.MaxNumNameLetters; ii++)
            {
                namebuffer[ii] = (ii < Name.Length) ? (byte)Name[ii] : (byte) 0;
            }
                
            writer.Write(namebuffer);

            //x0e     |Special item byte--each bit toggles something different
            //        | 0x80 = Card of Death 0x08 = Mark of Kings
            //        | 0x40 = Card of Moons 0x04 = Mark of Snake
            //        | 0x20 = Card of Sol   0x02 = Mark of Fire
            //        | 0x10 = Card of Love  0x01 = Mark of Force

            /////CardsMarks = reader.ReadByte();
            writer.Write(CardsMarks);

            //x0f     | Torches
            /////Torches = U3EditorUtil.read1Dec(reader);

            U3EditorUtil.write1Dec(writer, Torches);

            //x10     | Seems safe to change but unimportant overall
            //////x10 = reader.ReadByte();
            //writer.Write((byte)x10);
            writer.Write((byte)127);

            //x11     | Status: C7=good(letter G), C4=dead(D), D0=poison(P)
            ///Status = (CharacterStatus)reader.ReadByte();
            writer.Write((byte)Status);

            //x12     | Strength
            ////Strength = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, Strength);

            //x13     | Dexterity
            ////Dexterity = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, Dexterity);

            //x14     | Intelligence
            ////Intelligence = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, Intelligence);

            //x15     | Wisdom
            ///Wisdom = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, Wisdom);


            //x16     | race: [choices here]
            ////Race = (RaceType)reader.ReadByte();
            writer.Write((byte)Race);

            //x17     | profession
            ////Profession = (ProfessionType)reader.ReadByte();
            writer.Write((byte)Profession);

            //x18     | gender: CD = M(male,) C6 = F(female)
            ////Sex = (SexType)reader.ReadByte();
            writer.Write((byte)Sex);

            //x19     | magic points?
            ////Magic = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, Magic);

            //x1a-x1b | hit points
            //HP = U3EditorUtil.read2Dec(reader);
            U3EditorUtil.write2Dec(writer, HP);

            //x1c-x1d | maximum hit points
            //MaxHP = U3EditorUtil.read2Dec(reader);
            U3EditorUtil.write2Dec(writer, MaxHP);

            //x1e-x1f | experience
            //Experience = U3EditorUtil.TwoByteHex2Dec(reader.ReadUInt16());
            U3EditorUtil.write2Dec(writer, Experience);

            //x20-x21 | food
            //Food = U3EditorUtil.read2Dec(reader);
            U3EditorUtil.write2Dec(writer, Food);


            //x22     | max magic points????
            ////MaxMagic = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, MaxMagic);

            //x23-x24 | gold
            ////Gold = U3EditorUtil.read2Dec(reader);
            U3EditorUtil.write2Dec(writer, Gold);

            //x25     | Gems
            ////Gems = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, Gems);

            //x26     | Keys
            ////Keys = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, Keys);

            //x27     | Powder
            ////Powders = U3EditorUtil.read1Dec(reader);
            U3EditorUtil.write1Dec(writer, Powders);

            //x28     | Armor readied[0 = skin 1 = cloth 2 = leather 3 = chain
            //        | 4 = plate 5 = +2 chain 6 = +2 plate 7 = exotic]
            ////ArmourReadied = (ArmourType)U3EditorUtil.read1Dec(reader);
            writer.Write((byte)ArmourReadied);
            for (int i = 1; i < Constants.NumArmourType; i++)
                U3EditorUtil.write1Dec(writer, Armour[i]);

            //x29     | # of cloth owned [# of skin = 2 always]
            //x2a     | # of leather owned
            //x2b     | # of chain owned
            //x2c     | # of plate owned
            //x2d     | # of +2 chain owned
            //x2e     | # of +2 plate owned
            //x2f     | # of exotic owned

            //// WeaponReadied = (WeaponType)U3EditorUtil.read1Dec(reader);
            writer.Write((byte)WeaponReadied);

            for (int i = 1; i < Constants.NumWeaponType; i++)
                U3EditorUtil.write1Dec(writer, Weapons[i]);

            //x30     | Weapon readied[0 = hands 1 = dagger 2 = mace 3 = sling
            //        | 4 = axe 5 = bow 6 = sword 7 = 2 - h sword 8 = +2 axe
            //        | 9 = +2 bow a = +2 sword b = gloves c = +4 axe d = +4 bow
            //        | e = +4 sword f = exotic]
            //x31     | # of dagger owned [# of hands = 2 always]
            //x32     | # of mace owned
            //x33     | # of sling owned
            //x34     | # of axe owned
            //x35     | # of bow owned
            //x36     | # of sword owned
            //x37     | # of 2 handed sword owned
            //x38     | # of +2 axe owned
            //x39     | # of +2 bow owned
            //x3a     | # of +2 sword owned
            //x3b     | # of gloves owned
            //x3c     | # of +4 axe owned
            //x3d     | # of +4 bow owned
            //x3e     | # of +4 sword owned
            //x3f     | # of exotic owned

        }

    }
}
