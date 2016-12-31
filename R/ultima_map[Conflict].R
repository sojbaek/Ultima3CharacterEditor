library(EBImage);


loadTiles <- function(tilefile, numtiles, hres=16, vres=16, width=4) {
  #tilefile = 'Shapes.tiff';
  tileimage = readImage(tilefile); # 64 * 320 * 3
  tiles <- lapply(1:numtiles,
                  function(ii) { 
                    h= (ii-1)%%width;
                    v= (ii-1)%/%width;  
                    imgmat= tileimage@.Data[(h*hres+1):(h*hres+hres),(v*vres+1):(v*vres+vres),];
                    Image(imgmat, dim=c(dim(imgmat)[1],dim(imgmat)[2],3), colormode='Color');
                  })
  tiles;
}

convertUltima3MapToTiff<- function(mapfile, mapwidth=64, mapheight=64,divisor=4) {
  remaining <- NA;
  tifffile = gsub('.ULT','.tiff',basename(mapfile));
#  if (!file.exists(tifffile)) {
    hres=16; vres=16; width = 4;
    maplength=mapwidth*mapheight;
    
    tiles <- loadTiles('Shapes.tiff',80, hres=hres, vres=vres, width=width);
    numtiles = length(tiles);
    
    dat<-readBin(mapfile,"raw",n=maplength*2); 
    mapdat = as.numeric(dat[1:maplength]);
    remaining = dat[(maplength+1):length(dat)]
    
    mat = array(mapdat%/%divisor, c(mapwidth,mapheight))+1;    # somehow, need to divide codes by 4 to get the correct tile number
    rem = array(mapdat%%divisor, c(mapwidth,mapheight));    # somehow, need to divide codes by 4 to get the correct tile number
    canvas = array(0, c(mapwidth*hres, mapheight*vres,3))
    
    for (x in 1:maplength) {
      h = (x-1) %% mapwidth + 1;
      v = (x-1) %/% mapwidth + 1;
      mm= mat[x];
      canvas[((h-1)*hres+1):((h-1)*hres+hres),((v-1)*vres+1):((v-1)*vres+vres),] <- tiles[[mm]]@.Data;
    }
    
    im <- Image(canvas, dim=c(hres*mapwidth,vres*mapheight,3), colormode='Color');
    writeImage(im, tifffile,bits.per.sample=8)  
#  }
  as.numeric(remaining);
}

readDialog<- function(dat) {
  NextZero<-function(dat, position) {
    while (dat[position]!=0) {
      position = position+ 1;
    }
    position;
  }
  
  headerlength= dat[1];  jj =1;
  dialog<-{};
  for (k in 1:headerlength) {
    if (dat[k] != 0) {
      st = dat[k]+1;
      ed = NextZero(dat, st);
      dialog <- append(dialog, intToUtf8(dat[st:ed]));
    }
  }  
  dialog;
}

readNPC <- function(dat) {
  npcshape = dat[385:416] %/% 4;
  npcterrain = dat[417:448] %/% 4;
  npcx = dat[449:480];
  npcy = dat[481:512];
  npcdialog= as.numeric(dat[513:544]) %% 16;
  npctype = as.numeric(dat[513:544]) %/% 16;  # 0=stationary, 1=?, 2=?, 4=roaming, 8=following
  npc = data.frame(shape=npcshape, terrain=npcterrain, x = npcx, y = npcy, dialog=npcdialog, type =npctype);
  npc;
}

readU3MapNPCDialog<- function(mapfile) {
  remaining <- NA;
  maplength=64*64;
  dat<-readBin(mapfile,"raw",n=maplength*2); 
  mapdat = as.numeric(dat[1:maplength]);
  remaining = as.numeric(dat[(maplength+1):length(dat)]);
  NPC=readNPC(remaining);
  dialog=readDialog(remaining);
  list(NPC=NPC, dialog=dialog);
}


convertUltima3Conflict2Tiff<- function(mapfile) {
  remaining = convertUltima3MapToTiff(mapfile, mapwidth=11, mapheight=11,divisor=1);
}

#mapfile = 'D://GOG Galaxy//Games//Ultima 3//BRITISH.ULT';
mapfile = 'D://GOG Galaxy//Games//Ultima 3//YEW.ULT';

mapwidth=64; mapheight=64;divisor=4;


remaining <- convertUltima3MapToTiff(mapfile);

paste(sapply(as.numeric(remaining),function(x) ifelse(x>=32 & x<=127, sprintf('%s   ',intToUtf8(x)), sprintf('%4d',x))),collapse='')

dat = as.numeric(remaining);

yew = readU3MapNPCDialog('Ultima 3//YEW.ULT');
moon =readU3MapNPCDialog('Ultima 3//MOON.ULT');
devil= readU3MapNPCDialog('Ultima 3//DEVIL.ULT');
sosaria= readU3MapNPCDialog('Ultima 3//SOSARIA.ULT');


#convertUltima3MapToTiff('SOSARIA.ULT');
# convertUltima3MapToTiff('Ultima 3//YEW.ULT')
# convertUltima3MapToTiff('Ultima 3//AMBROSIA.ULT');
# convertUltima3MapToTiff('Ultima 3//BRITISH.ULT');
# convertUltima3MapToTiff('Ultima 3//DAWN.ULT');
# convertUltima3MapToTiff('Ultima 3//DEATH.ULT');
# convertUltima3MapToTiff('Ultima 3//DEVIL.ULT');
# convertUltima3MapToTiff('Ultima 3//EXODUS.ULT');
# convertUltima3MapToTiff('Ultima 3//FAWN.ULT');
# convertUltima3MapToTiff('Ultima 3//GREY.ULT');
# convertUltima3MapToTiff('Ultima 3//LCB.ULT');
# convertUltima3MapToTiff('Ultima 3//MONTOR_E.ULT');
# convertUltima3MapToTiff('Ultima 3//MONTOR_W.ULT');
# convertUltima3MapToTiff('Ultima 3//MOON.ULT')


#rem <- lapply(sprintf("Ultima 3//CNFLCT_%s.ULT",c('A','B','C','F','G','M','Q','R','S')),convertUltima3Conflict2Tiff);

#convertUltima3Conflict2Tiff("Ultima 3//TIME.ING")








