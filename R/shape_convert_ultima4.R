#setwd('C:\\Users\\baeks\\Google Drive\\VisualStudioProject\\Ultima3CharacterEditor\\R');
# This R script converts 4-bit bitmap image data SHAPES.ULT into a 64 * 320 RGB bitmap (tiff) image file

library(abind)
library(EBImage)

shapefile = "SHAPES.EGA"

dat<-readBin(shapefile,"raw",n=50000)   # 8192 bytes
# 32768 bytes = 65536 pixels = 256 * 16*16;
# 32768 =  256 icons * 128 bytes


icons=split(dat,sapply(1:256, function(x) rep(x,128)));
hwidth=16; vwidth=16;
#               Black                      
rc = strtoi(c("   0","   0","   0","   0","0xaa","0xaa","0xaa","0xaa","0x55","0x55","0x55","0x55","0xff","0xff","0xff","0xff"));
gc = strtoi(c("   0","   0","0xaa","0xaa","0x00","0x00","0x55","0xaa","0x55","0x55","0xff","0xff","0x55","0x55","0xff","0xff"));
bc = strtoi(c("   0","0xaa","   0","0xaa","   0","0xaa","   0","0xaa","0x55","0xff","0x55","0xff","0x55","0xff","0x55","0xff"));

cgato32 <- function(x) {
  aa = as.numeric(x)
  a3 = aa %/% 64 
  a2 = (aa %/% 16) %% 4
  a1 = (aa %/% 4) %% 4
  a0 = aa %% 4
  c(a3,a2,a1,a0);
}

egato32 <- function(x) {
  aa = as.numeric(x)
  a2 = aa %/% 16
  a0 = aa %% 16
  c(a2,a0);
}

imgmat = array(0, c(16*16, 16*16,3));
for (ii in 0:255) {
	hh = ii %% 16;
	vv = ii %/% 16;
	ic = icons[[ii+1]];
	ico <- do.call("c", lapply(ic, egato32));
	ico <- array(ico, c(hwidth,vwidth));
#	display(ico);
#	ico <- ico[,orderingsequence];
	#image(ico);
#	hr = (hh*16 + 1) : (hh*16+16);
#	vr = (vv*16 + 1) : (vv*16+16);
	hr = (hh*hwidth + 1) : (hh*hwidth+hwidth);
	vr = (vv*vwidth + 1) : (vv*vwidth+vwidth);

	imgmat[hr,vr,] = abind(array(rc[as.numeric(ico)+1],dim=c(hwidth,vwidth)),
	array(gc[as.numeric(ico)+1],dim=c(hwidth,vwidth)),array(bc[as.numeric(ico)+1],dim=c(hwidth,vwidth)),along=3);
}
timgmat = abind(t(imgmat[,,1]),t(imgmat[,,2]),t(imgmat[,,3]),along=3)
im <- Image(as.raster(timgmat, max=255), colormode='Color');

writeImage(im, "SHAPES.EGA.tiff")

