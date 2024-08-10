using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using distilled_community_recorder.Libs;

using static System.Environment;
using System.Diagnostics;

namespace CopyFolder
{


    class Program
    {
       

        public  void CopyAllFilesAndFolders(string source, string dest)
        {
     

            // เรียกใช้ฟังก์ชัน CopyAllFilesAndFolders
           // CopyAllFilesAndFolders(sourceDirectory, targetDirectory); 

            if (!Directory.Exists(source))
            {
                Console.WriteLine("Source directory does not exist!");
                return;
            }

            // สร้าง directory ที่ target หากยังไม่มี
            Directory.CreateDirectory(dest);
            // คัดลอกไฟล์ทั้งหมดใน source ไปยัง dest
            string[] files = Directory.GetFiles(source);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string sourceFile = file; // ไฟล์ต้นฉบับ
                string newFileName = name.Split('.')[0] + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString(); ; // ชื่อไฟล์ใหม่ (ไม่รวมส่วนขยาย)
                string newExtension = ".MP4"; // ส่วนขยายใหม่
                string destinationFolder = dest; // โฟลเดอร์ปลายทาง                                                  
                string destinationFile = Path.Combine(destinationFolder, newFileName + newExtension);  // สร้างเส้นทางไฟล์ปลายทางใหม่

                try
                {
                    // ย้ายไฟล์ พร้อมเปลี่ยนชื่อ
                    File.Move(sourceFile, destinationFile);
                    Console.WriteLine("ไฟล์ถูกย้ายและเปลี่ยนชื่อเรียบร้อยแล้ว");
                }
                catch (IOException ex)
                {
                    Console.WriteLine("เกิดข้อผิดพลาดในการย้ายไฟล์: " + ex.Message);
                }
                    /*
                string destpath = Path.Combine(dest, name);
                File.Copy(file, destpath, true);                
                System.IO.FileInfo fi = new System.IO.FileInfo(@dest + "\\" + name);
                            */





            }










            // คัดลอกโฟลเดอร์ย่อยทั้งหมดใน source ไปยัง dest
            /*    string[] dirs = Directory.GetDirectories(source);
                foreach (string dir in dirs)
                {
                    string name = Path.GetFileName(dir);
                    string destpath = Path.Combine(dest, name);
                    Directory.CreateDirectory(destpath);
                    CopyAllFilesAndFolders(dir, destpath);
                }
            */
        }
    }
}