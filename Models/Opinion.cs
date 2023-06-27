﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;


//This file is not to be modified
namespace TPLOCAL1.Models
{
    public class OpinionList
    {
        /// <summary>
        /// Function that alow to recover the opinions list inside an xml file
        /// </summary>
        /// <param name="file">file path</param>
        public List<Opinion> GetAvis(string file)
        {
            // instantiating empty list
            List<Opinion> opinionList = new List<Opinion>();

            // Creation of an XMLDocument object that alow to recover datas from the file
            XmlDocument xmlDoc = new XmlDocument();
            // Reading of the file thank to a StreamReader file
            StreamReader streamDoc = new StreamReader(file);
            string dataXml = streamDoc.ReadToEnd();
            // Loading data in the XmlDocument
            xmlDoc.LoadXml(dataXml);

            // Retrieve the nodes, convert them to the "Avis" object, and add them to the "OpinionList" list.
            // Loop through each XmlNode node with the path "root/row" (see xml file structure)
            // The SelectNodes method retrieves all nodes with the specified path.
            foreach (XmlNode node in xmlDoc.SelectNodes("root/row"))
            {
                // Retrieving data from child nodes.
                string LastName = node["LastName"].InnerText;
                string FirstName = node["FirstName"].InnerText;
                string OpinionGiven = node["OpinionGiven"].InnerText;

                // Creating the "Opinion" object to add to the results list.
                Opinion opinion = new Opinion
                {
                    LastName = LastName,
                    FirstName = FirstName,
                    OpinionGiven = OpinionGiven
                };

                // Adding the object to the list.
                opinionList.Add(opinion);
            }

            // Returning the list formed by processing to the calling method.
            return opinionList;
        }
    }

    // .: Info :.
    // This class can be extracted to a new C# page, but for the sake of this exercise, it can be left in the same page.
    // It's best to avoid having multiple classes inside the same page as it can complicate code readability and maintenance in the long run.
    /// <summary>
    /// Object that groups data related to reviews
    /// \nCan be modified
    /// </summary>
    public class Opinion
    {
        /// <summary>
        /// Last name
        /// </summary>
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }
        /// <summary>
        /// Review given (Possible values: O or N)
        /// </summary>
        public string OpinionGiven { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [Required(ErrorMessage = "Please enter your zip code.")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Town
        /// </summary>
        [Required(ErrorMessage = "Please enter your town.")]
        public string Town { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required(ErrorMessage = "Please enter your email address.")]
        //[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        /// <summary>
        /// Start date of training
        /// </summary>
        [Required(ErrorMessage = "Please enter the start date of training.")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Type of training
        /// </summary>
        [Required(ErrorMessage = "Please select a training type.")]
        public string TrainingType { get; set; }

        /// <summary>
        /// Review for Cobol Training
        /// </summary>
        public string CobolReview { get; set; }

        /// <summary>
        /// Training purpose
        /// </summary>
        public string TrainingPurpose { get; set; }





        // public bool NameIsReadOnly { get; set; }
        // public bool ForenameIsReadOnly { get; set; }

        // public Opinion()
        // {
        //     NameIsReadOnly = false; 
        //     ForenameIsReadOnly = false;
        // }
    }
}