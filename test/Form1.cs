using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace test
{
    public partial class Form1 : Form
    {

        public string url;
        XmlDocument doc = new XmlDocument();

        //List for all items
        List<Domain.Item> allItems = new List<Domain.Item>();

        //List For Members
        List<Domain.MemberCollection> members;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            url = "http://service.calendar.parliament.uk/calendar/events/list.xml?startdate=2015-11-16&enddate=2015-11-20";
            int memberId;
            string memName;
            string xmlStr;
            using (var wc = new WebClient())
            {
                xmlStr = wc.DownloadString(url);
            }
            doc.LoadXml(xmlStr);

            string description;


            foreach (XmlNode node in doc.DocumentElement)
            {
                int itemId = int.Parse(node.Attributes[0].Value);
                string startDate = node["StartDate"].InnerText;
                string endDate = node["EndDate"].InnerText;
                string startTime = node["StartTime"].InnerText;
                string endTime = node["EndTime"].InnerText;
                string category = node["Category"].InnerText;
                string type = node["Type"].InnerText;
                string house = node["House"].InnerText;



                if (node.SelectSingleNode("Description") == null)
                {
                    description = "No description";

                }

                else
                {
                    description = node["Description"].InnerText;

                }

                if (node["Members"].HasChildNodes)
                {
                    XmlNodeList node2 = node.SelectNodes("Members");
                    members = new List<Domain.MemberCollection>();

                    foreach (XmlNode a in node2)
                    {
                        for (int i = 0; i < a.ChildNodes.Count; i++)
                        {
                            memberId = int.Parse(a.ChildNodes[i].Attributes[0].Value);
                            memName = a.ChildNodes[i]["Name"].InnerText;
                            Domain.MemberCollection col = new Domain.MemberCollection(memberId, memName);
                            this.members.Add(col);
                        }

                    }
                }

                else
                {
                    members = new List<Domain.MemberCollection>();
                }


                //string description = node["Description"].Value;
                Domain.Item item = new Domain.Item(itemId, startDate, endDate, startTime, endTime, description, category, type, house, members);
                this.allItems.Add(item);
            }

            foreach (Domain.Item details in allItems)
            {
                items.Items.Add(details.ToString());

            }

        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            string xmlStr;
            int memberId;
            string party;
            string memberFrom;
            string fullTitle;

            url = "http://data.parliament.uk/membersdataplatform/services/mnis/members/query/id=579/";

            using (var wc = new WebClient())
            {
                xmlStr = wc.DownloadString(url);
            }

            doc.LoadXml(xmlStr);
            foreach (XmlNode node in doc.DocumentElement)
            {
                memberId = int.Parse(node.Attributes[0].Value);
                party = node["Party"].InnerText;
                memberFrom = node["MemberFrom"].InnerText;
                fullTitle = node["FullTitle"].InnerText;

                Domain.Member m = new Domain.Member(memberId, party, memberFrom, fullTitle);
                memberInfo.Items.Add(m.ToString());
            }
        }
    }
}
