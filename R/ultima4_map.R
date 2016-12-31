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

convertUltima4MapToTiff<- function(mapfile,hsize=32) {
  hres=16; vres=16; width = 16;
  mapwidth=hsize; mapheight=hsize;
  maplength=hsize * hsize;
  
  tiles <- loadTiles('SHAPES.EGA.tiff',256, hres=hres, vres=vres, width=width);
  numtiles = length(tiles);
  
  tifffile = gsub('.ULT','u4.tiff',mapfile);
  tifffile = gsub('.MAP','u4.tiff',tifffile);
  
  dat<-readBin(mapfile,"raw",n=100000); 
  mapdat = as.numeric(dat[1:maplength]);
  remaining = dat[(maplength+1):length(dat)]
  
  
  #mat = array(mapdat%/%4, c(mapwidth,mapheight))+1;    # somehow, need to divide codes by 4 to get the correct tile number
  mat = array(mapdat, c(mapwidth,mapheight))+1;    # somehow, need to divide codes by 4 to get the correct tile number
  
  canvas = array(0, c(mapwidth*hres, mapheight*vres,3))
  
  for (x in 1:maplength) {
    h = (x-1) %% mapwidth + 1;
    v = (x-1) %/% mapwidth + 1;
    mm= mat[x];
    canvas[((h-1)*hres+1):((h-1)*hres+hres),((v-1)*vres+1):((v-1)*vres+vres),] <- tiles[[mm]]@.Data;
  }
  
  if (length(remaining)>0)  {
    npcarray= array(as.numeric(remaining),c(16,16));
    
    for (ii in 1:16) {
      
      mm = npcarray[ii,2]+1;
      h = npcarray[ii,4]+1;
      v = npcarray[ii,6]+1;
      if (mm>1) {
        canvas[((h-1)*hres+1):((h-1)*hres+hres),((v-1)*vres+1):((v-1)*vres+vres),] <- tiles[[mm]]@.Data;
      } 
    }
  }
    
    
  im <- Image(canvas, dim=c(hres*mapwidth,vres*mapheight,3), colormode='Color');
  writeImage(im, tifffile,bits.per.sample=8)  
}

convertUltima4WorldMapToTiff<- function() {
  mapfile= "maps_u4//WORLD.MAP";
  hsize=32;
  hres=16; vres=16; regionwidth=8; regionheight = 8; 
  mapwidth=hsize; mapheight=hsize;
  maplength=hsize * hsize;
  numregion = regionheight*regionwidth;
  tiles <- loadTiles('SHAPES.EGA.tiff',256, hres=hres, vres=vres, width=16);
  numtiles = length(tiles);
  
  tifffile = gsub('.ULT','u4.tiff',mapfile);
  tifffile = gsub('.MAP','u4.tiff',tifffile);
  
  worlddat<-readBin(mapfile,"raw",n=100000); 
  regions=split(worlddat,sapply(1:64, function(x) rep(x,1024)));
  
  canvas = array(0, c(regionwidth*mapwidth*hres, regionheight*mapheight*vres,3))
  for (kk in 1:numregion) {
    dat = regions[[kk]];
    regionh = (kk-1) %% regionheight;
    regionv = (kk-1) %/% regionheight;
    mapdat = as.numeric(dat[1:maplength]);
    remaining = dat[(maplength+1):length(dat)]
    
    
    #mat = array(mapdat%/%4, c(mapwidth,mapheight))+1;    # somehow, need to divide codes by 4 to get the correct tile number
    mat = array(mapdat, c(mapwidth,mapheight))+1;    # somehow, need to divide codes by 4 to get the correct tile number
    
    print(paste(regionh,regionv));
    for (x in 1:maplength) {
      h = (x-1) %% mapwidth + 1;
      v = (x-1) %/% mapwidth + 1;
      
      mm= mat[x];
      xp=(regionh*hsize+h-1)*hres;
      yp=(regionv*hsize+v-1)*vres;
      canvas[(xp+1):(xp+hres),(yp+1):(yp+vres),] <- tiles[[mm]]@.Data;
    }
  }
#  if (length(remaining)>0)  {
#    npcarray= array(as.numeric(remaining),c(16,16));
#   
#    for (ii in 1:16) {
#      
#      mm = npcarray[ii,2]+1;
#      h = npcarray[ii,4]+1;
#      v = npcarray[ii,6]+1;
#      if (mm>1) {
#        canvas[((h-1)*hres+1):((h-1)*hres+hres),((v-1)*vres+1):((v-1)*vres+vres),] <- tiles[[mm]]@.Data;
#      } 
#    }
#  }
  
  
  im <- Image(canvas, dim=dim(canvas), colormode='Color');
  writeImage(im, tifffile,bits.per.sample=8)  
}

convertUltima4MapToTiff("maps_u4//BRITAIN.ULT")
convertUltima4MapToTiff("maps_u4//COVE.ULT")
convertUltima4MapToTiff("maps_u4//DEN.ULT")
convertUltima4MapToTiff("maps_u4//EMPATH.ULT")
convertUltima4MapToTiff("maps_u4//JHELOM.ULT")
convertUltima4MapToTiff("maps_u4//LCB_1.ULT")
convertUltima4MapToTiff("maps_u4//LCB_2.ULT")
convertUltima4MapToTiff("maps_u4//LYCAEUM.ULT")
convertUltima4MapToTiff("maps_u4//MAGINCIA.ULT")
convertUltima4MapToTiff("maps_u4//MINOC.ULT")
convertUltima4MapToTiff("maps_u4//MOONGLOW.ULT")
convertUltima4MapToTiff("maps_u4//PAWS.ULT")
convertUltima4MapToTiff("maps_u4//SERPENT.ULT")
convertUltima4MapToTiff("maps_u4//SKARA.ULT")
convertUltima4MapToTiff("maps_u4//TRINSIC.ULT")
convertUltima4MapToTiff("maps_u4//VESPER.ULT")
convertUltima4MapToTiff("maps_u4//YEW.ULT")


convertUltima4WorldMapToTiff()




