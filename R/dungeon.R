library(EBImage);
# 
# loadTiles <- function(tilefile, numtiles, hres=16, vres=16, width=4) {
#   #tilefile = 'Shapes.tiff';
#   tileimage = readImage(tilefile); # 64 * 320 * 3
#   tiles <- lapply(1:numtiles,
#                   function(ii) { 
#                     h= (ii-1)%%width;
#                     v= (ii-1)%/%width;  
#                     imgmat= tileimage@.Data[(h*hres+1):(h*hres+hres),(v*vres+1):(v*vres+vres),];
#                     Image(imgmat, dim=c(dim(imgmat)[1],dim(imgmat)[2],3), colormode='Color');
#                   })
#   tiles;
# }

#convertUltima3MapToTiff<- function(mapfile, mapwidth=64, mapheight=64,divisor=4) {
 
  dungeonfile = 'D://GOG Galaxy//Games//Ultima 3//TIME.ULT'
  
  dat<-readBin(dungeonfile,"raw",n=1000000); 
  mwidth =16;in
  mheight = 16;
  mlevel = 8;
  mapsize = mwidth*mheight*mlevel;
  
  dat.map <- dat[1:mapsize];
  dat.info <- dat[(mapsize+1) : (mapsize+16)];
  dat.message <- dat[(mapsize+17) : length(dat)];
  st = c(1,zi[-length(zi)]-1);
  ed = zi-1;
  vl = st<ed;
  st = st[vl];
  ed = ed[vl];
  messages = sapply(1:length(st), function(x) intToUtf8(dat.message[st[x]:ed[x]]))
  
  
  lapply(split(dat.message, c(sapply(1:8, function(x) rep(x,16)))), intToUtf8)
  
  remaining <- NA;
  
  tifffile = gsub('.ULT','.tiff',basename(mapfile));
  #  if (!file.exists(tifffile)) {
  hres=16; vres=16; width = 4;
  maplength=mapwidth*mapheight;
  
  tiles <- loadTiles('Shapes.tiff',80, hres=hres, vres=vres, width=width);
  numtiles = length(tiles);
  
  
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
  remaining;
}

convertUltima3Conflict2Tiff<- function(mapfile) {
  remaining = convertUltima3MapToTiff(mapfile, mapwidth=11, mapheight=11,divisor=1);
}

mapfile = 'D://GOG Galaxy//Games//Ultima 3//SOSARIA.ULT';
mapwidth=64; mapheight=64;divisor=4;


convertUltima3MapToTiff('D://GOG Galaxy//Games//Ultima 3//SOSARIA.ULT');
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


rem <- lapply(sprintf("Ultima 3//CNFLCT_%s.ULT",c('A','B','C','F','G','M','Q','R','S')),convertUltima3Conflict2Tiff);

#convertUltima3Conflict2Tiff("Ultima 3//TIME.ING")








