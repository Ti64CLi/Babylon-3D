1) build FreeImage for Android

	a) undefine HAVE_SEARCH_H (or fix file for TIFF4)
	b) add string.h for ImgAutoArray.h
	c) add following to dcraw_common.cpp

#ifdef ANDROID
void swab (const void *bfrom, void *bto, ssize_t n)
{
  const char *from = (const char *) bfrom;
  char *to = (char *) bto;

  n &= ~((ssize_t) 1);
  while (n > 1)
    {
      const char b0 = from[--n], b1 = from[--n];
      to[n] = b0;
      to[n + 1] = b1;
    }
}
#endif

	c) some files included with #include <...> but should be "..."
