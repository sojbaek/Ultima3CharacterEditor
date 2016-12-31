
#setwd('C:/Users/baeks/Google Drive/VisualStudioProject/Ultima3CharacterEditor/R/')

#library(EBImage);
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

exofile = 'Ultima 3//EXODUS.BIN'
#  dungeonfile = 'Ultima 3//PERINIAN.ULT'
#  dungeonfile = 'Ultima 3//FIRE.ULT'  

#  fountainfile = 'D://GOG Galaxy//Games//Ultima 3//FOUNTAIN.IMG'  # image   11x11 tile graphics
#  fountain.dat <-readBin(fountainfile,"raw",n=1000000); 


exodat <-as.numeric(readBin(exofile ,"raw",n=1000000));  # 1866 bytes
iszero = exodat == 0;
zerosum = cumsum(iszero);
zerosump = c(zerosum[2:length(zerosum)], zerosum[length(zerosum)]);
diff=(zerosump-zerosum) == 1;
rang=1:length(zerosum);
groupstart = rang[diff];
groups = split(exodat, zerosum);
grouplengths= unlist(lapply(groups,length))

groups[[notsingleton]]
notsingleton = grouplengths>1;

groupstart[notsingleton]
notsinglegroup = groups[grouplengths>1];
names(notsinglegroup) <- groupstart[grouplengths>1];

addr = names(notsinglegroup);
utf = sapply(notsinglegroup, intToUtf8);
dat <- data.frame(addr= addr[1:1252], text = utf[1:1252], stringsAsFactors = F);

write.csv(dat, file="exodus.bin.csv")
spt = split(exodat, zerosum)
ss <- as.numeric(exodat[1:10000]);
dgx=as.numeric(dgdat[seq(from=1, to=length(dgdat), by=2)])
dgy=as.numeric(dgdat[seq(from=2, to=length(dgdat), by=2)])