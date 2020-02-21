using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Threading;
public class Tester{
	
        //  public delegate void ScreenShotCallBack(int status, int imageSize, IntPtr imageData);
        //	private readonly ScreenShotCallBack _SubscriptionDelegate;

        

        public static void Main(string[] args){
            prog pr = new prog();

            // _callingDelegateA = img_data_save;
            int a = pr.add_nums();
            Console.WriteLine(a);
            pr.getByteArray();
            System.Console.WriteLine("Reached");

        }

}
public class prog{
    public void img_data_save(int imageSize, IntPtr data){ // function to save the data
            Console.WriteLine("Inside img_data_sav_function");
            var ImageData = new byte[imageSize];
            Console.WriteLine(imageSize);

            var sb = new StringBuilder("byte[] = ");
 
           
	        Marshal.Copy(data, ImageData, 0, imageSize);

             foreach (var b in ImageData)
                sb.Append(b + ", ");
 
            Console.WriteLine(sb.ToString());

            Console.WriteLine("After imagesize");
            string folder_path = "/home/tester/C++/";
            string filename = "copy_from_c++.png";
            string image_path = folder_path + filename;
            Stream ms = new MemoryStream(ImageData);
            BinaryReader br = new BinaryReader(ms);
	    //byte[] bytes = br.ReadBytes((Int32)ms.Length);
	   // File.WriteAllBytes(image_path, bytes);

       
  /*

            int width = 3;
            int height = 3;

            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var bitmapData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(ImageData, 0, bitmapData.Scan0, ImageData.Length);
            bmp.UnlockBits(bitmapData);
            bmp.Save(image_path);
*/
	    //Image img = Image.FromStream(ms);
            
	   // img.Save(image_path,ImageFormat.Jpeg);


	  Image returnImage = Image.FromStream(ms);
	  returnImage.Save(
          image_path,
          ImageFormat.Png
          );
        }
	    
        public delegate void delegateA(int imageSize, IntPtr imageData);

        delegateA _callingDelegateA;

        
        [DllImport("libimg_converterv2.so", CallingConvention=CallingConvention.ThisCall)]
        public static extern int add_nums(int a, int b);
        [DllImport("libimg_converterv2.so", CallingConvention=CallingConvention.ThisCall)]
        public static extern void getByteArray(delegateA _callingDelegate, string file);

    public prog()
    {
        _callingDelegateA = img_data_save;   
    }
    
    public int add_nums()
    {
        return add_nums(10, 2);

    }
    public void getByteArray()
    {
        getByteArray(_callingDelegateA, "sky.jpg");

    }
}


