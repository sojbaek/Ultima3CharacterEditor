using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Ultima3CharacterEditor
{
    public class Ultima3Doc
    {
        public const int mapwidth = 64;
        public const int mapheight = 64;
        public const int maplength = mapwidth * mapheight;

        const int MAXSHAPEFILESIZE = 65536;
        const int bitsPerRow = 4;
        const int numRow = 16;

        public Bitmap map = null;
        public Bitmap[] animatedMap;

        int NumCharacter;
        string partyFilename;
        string mapFilename;
        string tempmapFilename;
        string temppartyFilename;
        string shapeFilename;

        public U3Character[] Player { get; set; }

        public string u3Dir { get; set; }

        byte posX, posY;   // Player position in the sosaria map
        uint steps;        // # steps
        byte status;       // Party Status, 0
        byte dummy1,dummy2,dummy3,dummy4,dummy5,dummy6,dummy7;
        byte[] slots = new byte[4];
        Byte[] mapData;
        
        const int FOREST_CODE = 3;
        const int CHEST_CODE = 9;
        const int SHIP_CODE = 11;

        public enum tileType : Byte
        {
            WATER,PLAIN,BUSHES,FOREST,
            MOUNTAIN,DUNGEON,TOWN,CASTLE,
            STREET,CHEST,HORSE,FRIGATE,
            WHIRLPOOL1,SERPENT,OCTOPUS,PIRATE,
            MERCHANT1,LARK1,GUARD1,LB1,
            FIGHTER1,CLERIC1,WIZARD1,THIEF1,
            TROLL1,SKELETON1,GOLEM1,GARGOYLE1,
            SNATCH1,GRIFFIN1,DEVIL,EXODUS,
            FORCEFIELD,LAVA,MOONGATE,WALL,
            BLANK,LETTER_SPACE,LETTERA,LETTERB,
            LETTERC,LETTERD,LETTERE,LETTERF,
            LETTERG,LETTERH,LETTERI,LETTERV,
            LETTERY,LETTERL,LETTERM,LETTERN,
            LETTERO,LETTERP,LETTERW,LETTERR,
            LETTERS,LETTERT,SNAKETAIL,SNAKEHEAD,
            SHIELD1,SHIELD2,SHRINE,RANGER,
            MERCHANT2,LARK2,GUARD2,LB2,
            FIGHTER2,CLERIC2,WIZARD2,THIEF2,
            TROLL2,SKELETON2,GOLEM2,GARGOYLE2,
            SNATCH2,GRIFFIN2,DEVIL2,WHIRLPOOL2
        }
        
        public static string[] tileName = new string[] {
            "water","plain","bushes","forest",
            "mountain","dungeon","town","castle",
            "street","chest","horse","frigate",
            "whirlpool1","serpent","octopus","pirate",
            "merchant1","lark1","guard1","LB1",
            "fighter1","cleric1","wizard1","thief1",
            "troll1","skeleton1","golem1","gargoyle1",
            "snatch1","griffin1","devil","exodus",
            "forcefield","lava","moongate","wall",
            "blank","letter_space","letterA","letterB",
            "letterC","letterD","letterE","letterF",
            "letterG","letterH","letterI","letterV",
            "letterY","letterL","letterM","letterN",
            "letterO","letterP","letterW","letterR",
            "letterS","letterT","snaketail","snakehead",
            "shield1","shield2","shrine","ranger",
            "merchant2","lark2","guard2","LB2",
            "fighter2","cleric2","wizard2","thief2",
            "troll2","skeleton2","golem2","gargoyle2",
            "snatch2","griffin2","devil2","whirlpool2"
         };

        public static Dictionary<string, tileType> professionTileDic = new Dictionary<string, tileType>() {
            {"Wizard",tileType.WIZARD1},
            {"Fighter",tileType.FIGHTER1 },
            {"Cleric",tileType.CLERIC1},
            {"Paladin",tileType.FIGHTER2},
            {"Alchemist",tileType.WIZARD2},
            {"Barbarian",tileType.FIGHTER1},
            {"Ranger",tileType.RANGER},
            {"Thief",tileType.THIEF1},
            {"Illusionist",tileType.WIZARD2},
            {"Lark",tileType.LARK1},
            {"Druid",tileType.CLERIC2}
            };

        public static Dictionary<string, string> dungeonFileDic = new Dictionary<string, string>() {
            {"Doom","M.ULT"},
            {"Fires of Hell","FIRE.ULT" },
            {"Time Awaits","TIME.ULT"},
            {"Clues","P.ULT"},
            {"Perinian Depths","PERINIAN.ULT"},
            {"Mines of Morinia","MINE.ULT"},
            {"Dardin's Pit","DARDIN.ULT"}
        };


        public static string[] MapNames = new string[] {
            "Sosaria",
            "Ambrosia",
            "British",
            "Dawn",
            "Death",
            "Devil",
            "Exodus",
            "Fawn",
            "Grey",
            "LCB",
            "E Montor",
            "W Montor",
            "Moon",
            "Yew"};

        public static string[] MapFileNames = new string[] {
            "SOSARIA.ULT",
            "AMBROSIA.ULT",
            "BRITISH.ULT",
            "DAWN.ULT",
            "DEATH.ULT",
            "DEVIL.ULT",
            "EXODUS.ULT",
            "FAWN.ULT",
            "GREY.ULT",
            "LCB.ULT",
            "MONTOR_E.ULT",
            "MONTOR_W.ULT",
            "MOON.ULT",
            "YEW.ULT"};

        public static Dictionary<string, tileType> tileCodeDic;
            
        public Bitmap[] Shapes { get; set; }
        public byte[][] iconbuf;

        public Ultima3Doc(string u3dir)
        {
            this.u3Dir = u3dir;
            partyFilename = u3dir + "\\PARTY.ULT";
            mapFilename = u3dir + "\\SOSARIA.ULT";
            tempmapFilename = u3dir + "\\SOSARIA.ULT";
            temppartyFilename = u3dir + "\\PARTY.ULT";
            shapeFilename = u3dir + "\\SHAPES.ULT";

            tileCodeDic = new Dictionary<string, tileType>();
            for (int ii = 0; ii < tileName.Length; ii++)
                tileCodeDic[tileName[ii]] = (tileType) ii;
            
            ReadShapes();

            mapData = Ultima3Doc.ReadMapFromFile(mapFilename);

            SetupMapAnimation(numRow);
            ReadParty();
            PrintParty();
            
            Console.WriteLine("Ultima3Doc is set up.");
        }

        public Bitmap ImageTileForProfession(string profession)
        {
            return Shapes[(int)professionTileDic[profession]];
        }

        public int numCharacter()
        {
            if (Player == null) return 0;
            return NumCharacter;
        }

        public void ReadParty()
        {
            NumCharacter = 0;
            if (File.Exists(partyFilename))
            {
                bool isNotNull;

                using (BinaryReader reader = new BinaryReader(File.Open(partyFilename, FileMode.Open)))
                {
                    status = reader.ReadByte();   
                    dummy1 = reader.ReadByte();
                    dummy2 = reader.ReadByte();
                    steps = U3EditorUtil.read4Dec(reader);
                    dummy3 = reader.ReadByte();
                    posX = reader.ReadByte();
                    posY = reader.ReadByte();
                    for (int ii = 0; ii < 4; ii++)
                    {
                        slots[ii] = reader.ReadByte();
                        if (slots[ii] > 0) NumCharacter++;
                    }
                                            
                    dummy4 = reader.ReadByte();
                    dummy5 = reader.ReadByte();
                    dummy6 = reader.ReadByte();
                    dummy7 = reader.ReadByte();

                    Player = new U3Character[NumCharacter];
                    for (int kk = 0; kk < NumCharacter; kk++)
                    {
                        U3Character C = new U3Character();
                        isNotNull = C.readCharacterFromBinaryReader(reader);
                        if (isNotNull)
                        {
                            C.print();
                            Player[kk] = C;
                        }
                        else
                        {
                            Player[kk] = null;
                        }
                    }  
                }   

            }
            else
            {
                System.Windows.Forms.MessageBox.Show(String.Format("{0} not found", partyFilename), "Error: File Not Found");
                
            }
        }

        public void WriteParty()
        {
            if (NumCharacter == 0) return;

            if (File.Exists(partyFilename))
            {
                //bool isNotNull;

                using (BinaryWriter writer = new BinaryWriter(File.Open(temppartyFilename, FileMode.Create)))
                {
                    writer.Write(status);
                    writer.Write(dummy1);
                    writer.Write(dummy2);
                    U3EditorUtil.write4Dec(writer, steps);
                    writer.Write(dummy3);
                    writer.Write(posX);
                    writer.Write(posY);

                    for (int ii = 0; ii < 4; ii++)
                        writer.Write(slots[ii]);

                    writer.Write(dummy4);
                    writer.Write(dummy5);
                    writer.Write(dummy6);
                    writer.Write(dummy7);
                                       
                    for (int kk = 0; kk < NumCharacter; kk++)
                    {
                        Player[kk].writeCharacterToBinaryWriter(writer);
                    }
                }
            }
        }



        public static Byte[] ReadMapFromFile(string mapFilename)
        {
            Byte[]  mapData;
            if (!File.Exists(mapFilename))
            {
                System.Windows.Forms.MessageBox.Show(String.Format("{0} not found", mapFilename), "Error: File Not Found");
                return null;
            }
            using (BinaryReader reader = new BinaryReader(File.Open(mapFilename, FileMode.Open)))
            {
                mapData = reader.ReadBytes(maplength * 2);
            }
            return mapData;
        }

        public Byte getMapTile(int h, int v, int counter=0)   // h = 1 ~ 64, v = 1 ~ 64
        {
            return Ultima3Doc.getMapTileFromData(mapData, h, v, counter);
        }

        public static Byte getMapTileFromData(Byte [] mapData, int h, int v, int counter = 0)   // h = 1 ~ 64, v = 1 ~ 64
        {
            //   Console.WriteLine("({0},{1})", h, v);
            int tile = mapData[getPos(h, v)] >> 2;
            if ((counter >> 2) % 2 == 1)
            {
                if (tile >= 16 && tile <= 30)
                {
                    tile = tile + 48;
                }
                else
                {
                    if (tile >= 64 && tile <= 78)
                        tile = tile - 48;
                    else
                    {
                        if (tile == 12)
                            tile = 79;
                        else
                        {
                            if (tile == 79)
                                tile = 12;
                        }
                    }
                }
            }
            return (Byte)tile;
        }

        public static int getPos(int h, int v)
        {
            return (v - 1) * mapwidth + (h - 1);
        }
        
        public void placeShip(int h, int v)   // h = 1 ~ 64, v = 1 ~ 64
        {
            Console.WriteLine("Ultima3Doc::placeShip");
            mapData[getPos(h,v)] = SHIP_CODE << 2;
        }

        public void setPlayerLocation(int h, int v) // h = 1 ~ 64, v = 1 ~ 64
        {
            posX = (byte) h;
            posY = (byte) v;
        }

        public void changeForestIntoChests()
        {
            Console.WriteLine("Ultima3Doc::changeForestIntoChests");
            for (int ii= 0; ii< maplength; ii++)
            {
                if (mapData[ii] >> 2 == FOREST_CODE)
                {
                    // mapData[ii] = (CHEST_CODE << 2) | FOREST_CODE;
                    mapData[ii] = 39;
                }
            }

        }

        public void placeShips()
        {
            Console.WriteLine("Ultima3Doc::placeShips");
            placeShip(47, 19);
            //    placeShip(
        }

        public void PrintParty()
        {
            System.Console.WriteLine("Status={0}", status);
            System.Console.WriteLine("Steps={0}", steps);
            System.Console.WriteLine("posX={0}", posX);
            System.Console.WriteLine("posY={0}", posY);
            System.Console.WriteLine("Roster={0},{1},{2},{3}", slots[0], slots[1], slots[2], slots[3]);
        }
        
        public void WriteMap()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(tempmapFilename, FileMode.Create)))
            {
                writer.Write(mapData);
            }
        }

        public void Save()
        {
            WriteParty();
            WriteMap();
        }


        public void ReadShapes()
        {
            
            int bytesPerIcon;
            int numIcons;

            byte[] dat = null;

            byte[] rc = { 0, 0x55, 0xff, 0xff };  // light cyan      // CGA color palette
            byte[] gc = { 0, 0xff, 0x55, 0xff };  // light magenta
            byte[] bc = { 0, 0xff, 0xff, 0xff };     // white

            if (File.Exists(shapeFilename))
            {
                // bool isNotNull;
                using (BinaryReader reader = new BinaryReader(File.Open(shapeFilename, FileMode.Open)))
                {
                    dat = reader.ReadBytes(MAXSHAPEFILESIZE);  //dat < -readBin(shapefile, "raw", n = 10000)   # 5120 bytes
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(String.Format("{0} not found", shapeFilename), "Error: File Not Found");
                Shapes = null;
                return;
            }

            bytesPerIcon = bitsPerRow * numRow;
            numIcons = dat.Length / bytesPerIcon;  // 80
                                                   //# 5120byte = 20480 pixels = 8*10 * 16*16;
                                                   //# 5120 =  80 icons * 64 bytes

            byte[][] icons;
            int iconsize = 16;

            icons = new byte[numIcons][];
            for (int ii = 0; ii < numIcons; ii++)
            {
                icons[ii] = new byte[bytesPerIcon];
                for (int jj = 0; jj < bytesPerIcon; jj++)
                {
                    icons[ii][jj] = dat[ii * bytesPerIcon + jj];
                }
            }  //icons = split(dat, sapply(1:80, function(x) rep(x, 64)));

            int[] orderingsequence = { 0, 2, 4, 6, 8, 10, 12, 14, 1, 3, 5, 7, 9, 11, 13, 15 };

            int hh, vv;
            byte[] ic;
            byte[,] ico = new byte[iconsize, iconsize];

            Shapes = new Bitmap[numIcons];
            iconbuf = new byte[numIcons][];

            for (int ii = 0; ii < numIcons; ii++)
            {

                hh = ii % 4;
                vv = ii / 4;
                ic = icons[ii];

                for (int kk = 0; kk < bytesPerIcon; kk++)
                {
                    int jj = kk / 4;
                    byte aa = ic[kk];
                    int irow = orderingsequence[jj];
                    int icol = (kk % 4) * 4;
                    ico[icol, irow] = (byte)(aa / 64);
                    ico[icol + 1, irow] = (byte)((aa / 16) % 4);
                    ico[icol + 2, irow] = (byte)((aa / 4) % 4);
                    ico[icol + 3, irow] = (byte)(aa % 4);
                }  // ico is 16*16 matrix with values 0~3.

                int columns = iconsize;
                int rows = iconsize;
                int stride = iconsize * 3;

               
                Shapes[ii] = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
                Rectangle bound = new Rectangle(0, 0, columns, rows);
                BitmapData bData = Shapes[ii].LockBits(bound, ImageLockMode.WriteOnly, Shapes[ii].PixelFormat);

                /*the size of the image in bytes */
                int size = bData.Stride * bData.Height;
                iconbuf[ii] = new byte[iconsize * iconsize * 3];

                int tt = 0;
                for (int jj = 0; jj < iconsize; jj++)
                {
                    for (int kk = 0; kk < iconsize; kk++)
                    {
                        iconbuf[ii][tt++] = bc[ico[kk, jj]];  //Green
                        iconbuf[ii][tt++] = gc[ico[kk, jj]];  //Green
                        iconbuf[ii][tt++] = rc[ico[kk, jj]];
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(iconbuf[ii], 0, bData.Scan0, iconbuf[ii].Length);
                Shapes[ii].UnlockBits(bData);
            }

           
        }

        static void pasteBitmapAt(int hh, int vv, byte[] sourceBitmap, byte[] targetBitmap, int tilewidth, int tileheight, int targetwidth, int targetheight, int counter = 0)
        {
            for (int jj = 0; jj < tileheight; jj++)
            {
                int baseaddr = (((vv-1)  * tileheight + jj) * targetwidth  + (hh-1)*tilewidth) * 3;
                for (int ii = 0; ii < tilewidth; ii++)
                {
                    int sourceaddr = (((jj+tileheight - counter)%tileheight) * tilewidth + ii) * 3;
                    targetBitmap[baseaddr + ii * 3] = sourceBitmap[sourceaddr];
                    targetBitmap[baseaddr + ii * 3+1] = sourceBitmap[sourceaddr+1];
                    targetBitmap[baseaddr + ii * 3+2] = sourceBitmap[sourceaddr+2];
                }
            }              
        }

        public void SetupMapAnimation(int numFrame)
        {
            Console.WriteLine("Ultima3Doc.SetupMap()");
            map = drawMap(0);
            animatedMap = Ultima3Doc.SetupMapAnimationFromData(mapData, iconbuf, numFrame);
        }


        public static Bitmap[] SetupMapAnimationFromData(byte[] mapData, byte[][] iconbuf, int numFrame)
        {
            // map = drawMap(0);
            Bitmap[] animatedMap = null;
            if (numFrame > 0)
            {
                animatedMap = new Bitmap[numFrame];
                for (int ii = 0; ii < numFrame; ii++)
                {
                    animatedMap[ii] = Ultima3Doc.DrawMapFromData(mapData, iconbuf, ii);
                }
            }
            return animatedMap;
        }


        public Bitmap drawMap(int counter=0)
        {
            return Ultima3Doc.DrawMapFromData(mapData, iconbuf, counter);
        }

        public static Bitmap DrawMapFromData(byte [] mapData, byte[][] iconbuf, int counter = 0)
        {
            int iconsize = 16;
            int columns = iconsize * 64;
            int rows = iconsize * 64;
            int stride = columns * 3;
            int tileidx;

            counter = counter % iconsize;

            Rectangle bound = new Rectangle(0, 0, columns, rows);
            Bitmap map = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
            byte[] mapbuf = new byte[columns * rows * 3];

            BitmapData bData = map.LockBits(bound, ImageLockMode.WriteOnly, map.PixelFormat);

            /*the size of the image in bytes */
            //int size = bData.Stride * bData.Height;

            for (int vv = 1; vv <= 64; vv++)
            {
                for (int hh = 1; hh <= 64; hh++)
                {
                    tileidx = Ultima3Doc.getMapTileFromData(mapData, hh, vv, counter);
                    if (!(tileidx == 0 || (tileidx >= 32 && tileidx <= 34)))  // If the tile is not 'water', 'lava','teleport','force field'
                    {
                        pasteBitmapAt(hh, vv, iconbuf[tileidx], mapbuf, 16, 16, columns, rows, 0);
                    }
                    else
                    {
                        pasteBitmapAt(hh, vv, iconbuf[tileidx], mapbuf, 16, 16, columns, rows, counter);
                    }

                }
            }
            System.Runtime.InteropServices.Marshal.Copy(mapbuf, 0, bData.Scan0, mapbuf.Length);
            map.UnlockBits(bData);
            return map;
        }
    }
}
