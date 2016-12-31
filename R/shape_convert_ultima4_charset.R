#setwd('C:\\Users\\baeks\\Google Drive\\VisualStudioProject\\Ultima3CharacterEditor\\R');
# This R script converts 4-bit bitmap image data SHAPES.ULT into a 64 * 320 RGB bitmap (tiff) image file

library(abind)
library(EBImage)

shapefile = "CHARSET.EGA"

dat<-readBin(shapefile,"raw",n=10000)   # 8192 bytes
# 8192 bytes = 16384 pixels = 64 * 16*16;
# 5120 =  64 icons * 128 bytes


icons=split(dat,sapply(1:256, function(x) rep(x,32)));
hwidth=8; vwidth=8;

rc = strtoi(c("0","0","0","0","0xaa","0xaa","0xaa","0xaa","0x55","0x55","0x55","0x55","0xff","0xff","0xff","0xff"));
gc = strtoi(c("0","0","0xaa","0xaa", "0x00", "0x00","0x55","0xaa","0x55","0x55","0xff","0xff","0x55","0x55","0xff","0xff"));
bc = strtoi(c("0","0xaa","0","0xaa","0","0xaa","0","0xaa","0x55","0xff","0x55","0xff","0x55","0xff","0x55","0xff"));

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

orderingsequence = rev(c(16,8,15,7,14,6,13,5,12,4,11,3,10,2,9,1));

imgmat = array(0, c(16*8, 16*8,3));
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

im <- Image(imgmat, dim=c(dim(imgmat)[1],dim(imgmat)[2],3), colormode='Color');

writeImage(im, "charset.tiff",bits.per.sample=8);