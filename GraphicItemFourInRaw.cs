using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FourInRow
{
    class GraphicItemFourInRaw
    {
       private Types currentType; // this object's type
       private Bitmap pieceImage; // this object's image

       // default display location
       private Rectangle targetRectangle = 
          new Rectangle( 0, 0, 47, 36 );

       // construct piece
       public GraphicItemFourInRaw(Types type, int xLocation, 
          int yLocation, Bitmap sourceImage )
       {
          currentType = type; // set current type
          targetRectangle.X = xLocation; // set current x location
          targetRectangle.Y = yLocation; // set current y location

          // obtain pieceImage from section of sourceImage
          pieceImage = sourceImage.Clone( 
             new Rectangle(0, 0, 47, 36), 
             //targetRectangle,
             System.Drawing.Imaging.PixelFormat.Format32bppArgb
             );
          SetLocation(xLocation, yLocation);
       } // end method ChessPiece

       // draw chess piece
       public void Draw( Graphics graphicsObject )
       {
          graphicsObject.DrawImage( pieceImage, targetRectangle );
       } // end method Draw

       // obtain this piece's location rectangle
       public Rectangle GetBounds()
       {
          return targetRectangle;
       } // end method GetBounds

       // set this piece's location
       public void SetLocation( int xLocation, int yLocation )
       {
          targetRectangle.X = xLocation;
          targetRectangle.Y = yLocation;
       } // end method SetLocation
    }
}
