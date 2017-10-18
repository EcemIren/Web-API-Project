using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services
{
    public class CallService
    {
        public string url;
        XmlDocument doc = new XmlDocument();

        //List for all items
        List<Domain.Item> allItems = new List<Domain.Item>();

        //List For Members
        List<Domain.MemberCollection> members;

        List<Domain.Item> filtered = new List<Domain.Item>();

        //Call this service for displaying items of current week
        public List<Domain.Item> initialItems()
        {
            url = "http://service.calendar.parliament.uk/calendar/events/list.xml?startdate=2017-04-17&enddate=2017-04-21";

            /* url = "http://service.calendar.parliament.uk/calendar/events/list.xml?date=thisweek"; */

            int memberId,itemId;
            string startDate, endDate, category, type, house, startTime, endTime, description; 
            string memName;
            string xmlStr;

            using (var wc = new WebClient())
            {
                xmlStr = wc.DownloadString(url);
            }
            doc.LoadXml(xmlStr);

            foreach (XmlNode node in doc.DocumentElement)
            {
                itemId = int.Parse(node.Attributes[0].Value);
                startDate = node["StartDate"].InnerText;
                endDate = node["EndDate"].InnerText;
                startTime = node["StartTime"].InnerText;
                endTime = node["EndTime"].InnerText;
                category = node["Category"].InnerText;
                type = node["Type"].InnerText;
                house = node["House"].InnerText;
           
                if(node.SelectSingleNode("Description") == null)
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
                Domain.Item item = new Domain.Item(itemId, startDate, endDate, startTime, endTime, category,type, house,description,members);
                this.allItems.Add(item);
            }

          
                for (int i = 0; i < allItems.Count; i++)
                {
                    if ((string.Compare(allItems[i].type,"Main Chamber")==0) && (string.Compare(allItems[i].house,"Commons")==0))
                    {
                       filtered.Add(allItems[i]);
                    }
                }
            
            return this.filtered;
        }

        //Call this service for displaying items of specific week
        public void loadItems(string startDate, string endDate)
        {
            url = "http://service.calendar.parliament.uk/calendar/events/list.xml?startdate=" + startDate + "&enddate=" + endDate;
            doc.LoadXml(url);
        }

        public Domain.Member loadMemberDetails(int id)
        {
            string xmlStr;
            int memberId;
            string party;
            string memberFrom;
            string fullTitle;
            Domain.Member m;

            url = "http://data.parliament.uk/membersdataplatform/services/mnis/members/query/id="+id+"/";

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

                m = new Domain.Member(memberId, party, memberFrom, fullTitle);
                return m;
            }

            return null;
            
        }
    }
}
