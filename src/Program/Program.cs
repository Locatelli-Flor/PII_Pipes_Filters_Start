using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            FiltroGuardar Guardar1 = new FiltroGuardar(picture, @"guardado1.jpg");
            FiltroGuardar Guardar2 = new FiltroGuardar(picture, @"guardado2.jpg");

            PipeNull Nulo = new PipeNull();
            PipeSerial Guardado2 = new PipeSerial(Guardar2, Nulo);
            PipeSerial Serial2 = new PipeSerial(new FilterNegative(), Guardado2);
            
            PipeSerial Guardado1 = new PipeSerial(Guardar1, Serial2);
            PipeSerial Serial1 = new PipeSerial(new FilterGreyscale(), Guardado1);
            Serial1.Send(picture);


        }
    }
}