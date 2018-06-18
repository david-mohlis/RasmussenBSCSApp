using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmussenBSCSApp
{
    class BL_ContentPage
    {
        public static string CourseNumberOutput { get; set; }
        public static string CourseNameOutput { get; set; }
        public static string CourseDescriptionOutput { get; set; }
        public static string CourseCredits { get; set; }
        public static string CoursePrereq { get; set; }
        public static string ProgramVisionOutput { get; set; }
        public static string ProgramObjectiveOutput { get; set; }

        public static void OutputBuilder(string[] varOutput)
        {
            CourseNumberOutput = "Course Number:    " + varOutput[0];
            CourseNameOutput = "Course Name:    " + varOutput[1];
            CourseDescriptionOutput = "Course Description:  " + varOutput[2];
            CourseCredits = "Credits:   " + varOutput[3];
            CoursePrereq = "Prerequisite:   " + varOutput[4];
        }

        public static void ProgramInfoBuilder(string[] varOutput)
        {
            ProgramVisionOutput = "<italic>Program Vision: </italic>" + varOutput[0];
            ProgramObjectiveOutput = "<italic>Program Objective: </italic>" + varOutput[1];
        }

        public static void ProgramInformation()
        {
            string[] proginfo = new string[] { "Rasmussen College's Computer Science Bachelor completer program is focused on preparing students to be independent, strong leaders, and technical experts in enterprise systems. Graduates will be prepared to apply technical knowledge resulting in real world business solutions. This program is differentiated by an AcceleratED learning format and career placement opportunities with well-known technology partners. This program integrates real world experience including problem solving, strategic and critical thinking, technical architecture, and project management. Industry-experienced faculty create a student learning environment of collaborating with team members of diverse perspectives. ", "Graduates of the Computer Science program learn how to design, develop, and deploy information systems that leverage cloud computing, mobile technology, and business analytics. They understand the enterprise architecture that underlies a business and how to apply an application architecture to specific needs within the enterprise framework. Students develop mastery in business concepts, programming languages, distributed database utilization, and end-to-end information security practices. They can analyze and evaluate business problems; design and illustrate technical solutions, code and deploy distributed software applications then test and integrate the information system into day-to day business operations. Graduates value communication, critical thinking, problem solving, and diversity awareness." };
            ProgramInfoBuilder(proginfo);
        }

        public static void CDA3315C()
        {
            string[] cda3315c = new string[] { "CDA3315C", "Fundamentals of Enterprise Architecture", "This course is the study of business enterprise analysis, design, planning and implementation. It places focus on working with stakeholders, modeling business data flows and interfaces, determining the information security risk for an organization, and re-engineering business processes. Topics include current software development methodologies, business process modeling, and enterprise information security methodologies. This course will prepare students to work with stakeholders to ensure that information technology is in alignment with the goals of the business.", "4", "None" };
            OutputBuilder(cda3315c);
        }

        public static void MAN3504()
        {
            string[] man3504 = new string[] { "MAN3504", "Operations Management", "In this course students examine the operations function of managing people, information, technology, materials, and facilities to produce goods and services. Specific areas covered will include: designing and managing operations; purchasing raw materials; controlling and maintaining inventories; and producing goods or services that meet customers' expectations. Quantitative modeling will be used for solving business problems.", "4", "None" };
            OutputBuilder(man3504);
        }

        public static void CDA3428C()
        {
            string[] cda3428c = new string[] { "CDA3428C", "Fundamentals of Distributed Application Architecture", "This course is the study of the design and use of distributed software applications as part of a enterprise architecture in a typical business. It places focus on the software development process, business process analysis, and generating functional requirements for business technology. Topics include software architecture, business process analysis, agile development, and scalability. This course will prepare students for producing a software development project plan, documenting hardware and software requirements to support current and future transaction loads, and modeling end-to-end data flows for a given business process.", "4", "None" };
            OutputBuilder(cda3428c);
        }

        public static void CIS3801C()
        {
            string[] cis3801c = new string[] { "CIS3801C", "Fundamentals of Mobile Web Application Development", "This course presents the fundamentals of mobile web applications development. It places a focus on implementing well-defined mobile application standards, while designing a mobile application as a business solution to a real business scenario. Topics include mobile application standards, selecting appropriate content adaptation strategies, and following the system's development life cycle to plan, design, test, and deploy a mobile application. This course will prepare students to develop a professional mobile application that meets today’s business standards.", "4", "None" };
            OutputBuilder(cis3801c);
        }

        public static void CIS4655C()
        {
            string[] cis4655c = new string[] { "CIS4655C", "Advance Mobile Web Application Development", "This course is the study of advanced mobile application development. It places a detailed focus on building a mobile application user interface, planning and designing database models, and deploying mobile applications to emulators, as well as popular mobile application stores. Topics include designing a professional graphical prototype of the user interface, designing navigation that meets usability requirements, constructing data models and databases, interfacing code to databases, and testing then deploying an application to popular application stores. This course will prepare students to create more advanced mobile applications that interact with cloud-based databases.", "4", "Fundamentals of Mobile Web Applications Development" };
            OutputBuilder(cis4655c);
        }

        public static void GEB3422()
        {
            string[] geb3422 = new string[] { "GEB3422", "Business Project Management", "This course provides students with the essential elements and foundational standards used to manage projects, programs and portfolios in any organization. Students will develop project scope and scheduling skills as well as assess program bidding and proposal processes. They will evaluate the impact of scope definition, and explore how to manage teams, expectations and project stakeholders.", "4", "None" };
            OutputBuilder(geb3422);
        }

        public static void CTS4557()
        {
            string[] cts4557 = new string[] { "CTS4557", "Emerging Trends in Technology", "This course is the study of emerging technologies. It places focus on technology impact on business and society in general. Topics include the relationship between emerging technologies and business opportunities, analysis of costs and savings of implementing particular technologies, legal and ethical issues affecting technology, challenges of adapting new technologies, and impacts of technology.", "3", "None" };
            OutputBuilder(cts4557);
        }

        public static void CIS3917C()
        {
            string[] cis3917c = new string[] { "CIS3917C", "Fundamentals of Distributed Database Management", "This course is the study of distributed databases and the technical architecture they reside on. It places focus on geographically separated databases where through database replication, end users experience database transparency. Topics include the differences between distributed databases and stand-alone database management systems, scalability, replication, and overall high availability concepts as they relate to distributed databases. This course will prepare students to implement enterprise worthy, geographically separated databases.", "4", "None" };
            OutputBuilder(cis3917c);
        }

        public static void CTS3265C()
        {
            string[] cts3265c = new string[] { "CTS3265C", "Introduction to Business Intelligence", "This course is the study of the skills and techniques for analyzing business performance data to provide support for business planning. It places focus on using query development, reporting, and analytical tools to help guide business decision-making. Topics include statistical analysis, basic database design, and business process modeling. This course will prepare students to utilize information to support decision-making.", "4", "None" };
            OutputBuilder(cts3265c);
        }

        public static void CIS4793C()
        {
            string[] cis4793c = new string[] { "CIS4793C", "Database Implementation Strategies for Programmers", "The focus of this course is to provide programmers the information necessary to interface mobile software applications with cloud-based distributed databases. Topics include a review of database fundamentals, database connectivity, query optimization, and the use of application program interfaces (APIs) as they relate to specific vendor databases. This course will prepare students to extract data from a distributed database and then present the data within a mobile software application.", "4", "None" };
            OutputBuilder(cis4793c);
        }

        public static void CIS4836C()
        {
            string[] cis4836c = new string[] { "CIS4836C", "Web Analytics", "This course is the study of contemporary business analytics tools. It places a focus on determining the most appropriate product or technology for building data visualizations and dashboards. Topics include identifying analytical tools, highlighting various input and output data formats, identifying different types of data visualizations, and constructing business-oriented dashboards. This course will prepare students to be able to create data visualizations and dashboards based on provided business requirements.", "4", "None" };
            OutputBuilder(cis4836c);
        }

        public static void CTS3302C()
        {
            string[] cts3302c = new string[] { "CTS3302C", "Fundamentals of Cloud Computing", "This course will introduce students to various technologies and services utilized in cloud computing. The course will focus on practical application of cloud deployment methodologies. Topics include the evolution of cloud computing technology, examination of cloud deployment and cloud service models, and designing a cloud computing strategy to meet specific business needs.", "4", "None" };
            OutputBuilder(cts3302c);
        }

        public static void CTS4623C()
        {
            string[] cts4623c = new string[] { "CTS4623C", "Advanced Cloud Computing Technologies", "This course will provide students with an in-depth understanding of computing technologies and services for enterprise level application deployment projects. The course will focus on practical aspects of cloud based application architecture and deployment methodologies, using the Microsoft Azure cloud platform. Topics include application scalability principles, application performance and benchmarking tools, authentication and authorization security issues, cloud deployment platform selection criteria, asset cataloging and management, and other advanced cloud deployment topics.", "4", "Cloud Computing Fundamentals" };
            OutputBuilder(cts4623c);
        }

        public static void CIS4910C()
        {
            string[] cis4910c = new string[] { "CIS4910C", "Computer Science Capstone", "This course is the culmination of the diverse skill set previously gained throughout the program. It places focus on project management skills, communication, and critical thinking as they relate to constructing an end-to-end technical solution. This course will incorporate a different project focus each term where students will collaborate in the development of a mobile/cloud application system.", "3", "Technology Bachelor's Student in Final Term" };
            OutputBuilder(cis4910c);
        }

        public static void COP3488C()
        {
            string[] cop3488c = new string[] { "COP3488C", "Universal Windows Application Programming I", "This course provides students an introduction to the basic features of the Microsoft C# programming language as it applies to Universal Windows Application mobile application development. Students will review the history, features, and advantages of the C# programming language, utilize the Visual Studio programming environment, demonstrate a mastery of C# programming basics, and develop a basic Universal Windows Application.", "4", "Enterprise Architecture, Distributed Application Architecture" };
            OutputBuilder(cop3488c);
        }

        public static void COP4474C()
        {
            string[] cop4474c = new string[] { "COP4474C", "Universal Windows Application Programming II", "This course presents advanced application design and Microsoft C# programming techniques related to Universal Windows Application development. Students will analyze user interface design and the Windows features that support it, demonstrate a mastery of Microsoft user interface tools, construct a C# database application, and develop a basic C# mobile application that accesses Microsoft Azure.", "4", "Universal Windows Applications Programming I" };
            OutputBuilder(cop4474c);
        }

        public static void COP4777C()
        {
            string[] cop4777c = new string[] { "COP4777C", "Universal Windows Application Programming III", "This course focuses on the development of Universal Windows mobile applications that access cloud computing resources. Students will explore the software development kits (SDKs) available from commercial cloud vendors, demonstrate a mastery of the Amazon Web Services Mobile SDK, demonstrate a mastery of the Microsoft Windows Azure Mobile Services SDK, and incorporate AWS or Azure functionality into a working Universal Windows mobile application.", "4", "Universal Windows Applications Programming II" };
            OutputBuilder(cop4777c);
        }

        public static string CreatedBy { get; set; }
    }
}
