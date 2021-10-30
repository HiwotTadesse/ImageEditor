using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace ImageEditor
{
    class database
    {
        MySqlConnection mysql;
        // ImageHandler imageHandler = new ImageHandler();
        string conString;
        public database()
        {

        }
        public void connection()
        {
            conString = "server=localhost;user id=root;database=editedimages";
            mysql = new MySqlConnection(conString);
        }
        public bool insertImageInToDatabase(string name,
            string notes = ""
            )
        {
            connection();

            //Console.WriteLine(stream);
            MySqlCommand cmd = mysql.CreateCommand();
            cmd.CommandText = $"INSERT INTO savednotes(name, notes) VALUES('{name}', '{notes}')";
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@notes", MySqlDbType.VarChar).Value = notes;
          //  cmd.Parameters.Add("@Image", MySqlDbType.Blob).Value = Image;
            mysql.Open();
            cmd.ExecuteNonQuery();

            mysql.Close();

            return true;

        }

        public Dictionary<string, string> retriveImage()
        {
            connection();
            string pp = "";
            string nn = "";
            MySqlCommand cmd = mysql.CreateCommand();
            cmd.CommandText = $"Select name ,notes from savedNotes";

            mysql.Open();
            MySqlDataReader read = cmd.ExecuteReader();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            while (read.Read())
            {
                
                pp = (string)read["name"];
                nn = (string)read["notes"];
                if (read.HasRows)
                {
                    dict.Add(pp, nn); 
                } 
            }
            
            return dict;
        }
        public bool retrieveName(string name) {
            string savedname = "";
            bool truth = false;
            connection();
            MySqlCommand cmd = mysql.CreateCommand();
            cmd.CommandText = $"Select name from savedNotes";
            mysql.Open();
            MySqlDataReader read = cmd.ExecuteReader();
            List<string> names = new List<string>();
            while (read.Read()) {
                savedname = (string)read["name"];
                names.Add(savedname);
            }
            foreach (var item in names)
            {
                if (name.Equals(item))
                {
                    truth = true;
                }
                else {
                    truth = false;
                }
            }
            return truth;

        }



    }

}