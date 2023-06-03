# TinyImg
!!!UNFINISHED!!! DO NOT EXPECT A FULLY WORKING LIBRARY

A binary format that stores images in the CGA colour space, one byte per pixel, while also having unoptimised conversion algorithms.
Just a project to test my C# programming skills, and understanding of binary formats.

Working:
  - Conversion to PNG (and every format that ImageSharp that can export to)
  - Serialisation to the `Image` class and deserialisation to binary `.timg`  files

Plans:
  - Optimise the conversion algorithms
  - Work on a CLI app that does the conversion via images fed via flags
