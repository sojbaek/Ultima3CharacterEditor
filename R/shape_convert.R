#setwd('C:\\Users\\baeks\\Google Drive\\VisualStudioProject\\Ultima3CharacterEditor\\R');
# This R script converts 4-bit bitmap image data SHAPES.ULT into a 64 * 320 RGB bitmap (tiff) image file

library(abind)
library(EBImage)

shapefile = "SHAPES.ULT"

dat<-readBin(shapefile,"raw",n=10000)   # 5120 bytes
# 5120byte = 20480 pixels = 8*10 * 16*16;
# 5120 =  80 icons * 64 bytes


icons=split(dat,sapply(1:80, function(x) rep(x,64)));

rc = c(0,0,255,255);
gc = c(0,255,0,255);
bc = c(0,255,255,255);

cgato32 <- function(x) {
  aa = as.numeric(x)
  a3 = aa %/% 64 
  a2 = (aa %/% 16) %% 4
  a1 = (aa %/% 4) %% 4
  a0 = aa %% 4
  c(a3,a2,a1,a0);
}

orderingsequence = rev(c(16,8,15,7,14,6,13,5,12,4,11,3,10,2,9,1));

imgmat = array(0, c(4*16, 20*16,3));
for (ii in 0:79) {
	hh = ii %% 4;
	vv = ii %/% 4;
	ic = icons[[ii+1]];
	ico <- do.call("c", lapply(ic, cgato32));
	ico <- array(ico, c(16,16));
	ico <- ico[,orderingsequence];
	#image(ico);
	hr = (hh*16 + 1) : (hh*16+16);
	vr = (vv*16 + 1) : (vv*16+16);
	imgmat[hr,vr,] = abind(array(rc[as.numeric(ico)+1],dim=c(16,16)),array(gc[as.numeric(ico)+1],dim=c(16,16)),array(bc[as.numeric(ico)+1],dim=c(16,16)),along=3);
}
#timgmat = abind(t(imgmat[,,1]),t(imgmat[,,2]),t(imgmat[,,3]),along=3)
im <- Image(imgmat, colormode='Color');

writeImage(im, "shapes.tiff",bits.per.sample=8)


