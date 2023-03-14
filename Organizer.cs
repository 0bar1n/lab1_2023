using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class Organizer
    {
        public List<Data> list = new List<Data>();

        public Organizer(Data data)
        {
            list.Add(data);
        }
        public Organizer()
        {
        }

        public void add(Data data)
        {
            this.list.Add(data);
        }

        public void remove(int index)
        {
            if (index < list.Count)
                list.RemoveAt(index);
        }

        public List<Data> findByCategory(EventType type)
        {
            List<Data> tmpList = new List<Data>();
            list.ForEach(item =>
            {
                if (item.eventType == type)
                    tmpList.Add(item);

            });

            return tmpList;
        }







        public List<Data> findByTime(String time)
        {
            List<Data> tmpList = new List<Data>();
            list.ForEach(item =>
            {
                int time1 = item.Time.Hours * 3600 + item.Time.Minutes;
                double time2 = int.Parse(time.Split(':')[0]) * 3600 + int.Parse(time.Split(':')[1]);
                if (time2 >= time1)
                    tmpList.Add(item);

            });

            return tmpList;
        }


        public void sortByData(int direction = 0)
            {
            list.Sort((x, y) => {
                int dataX = x.Date.Month * 12 + x.Date.Day;
                int dataY = y.Date.Month * 12 + y.Date.Day;

                if(direction == 0)
                {
                    if (dataX > dataY)
                        return 1;
                    if (dataX < dataY)
                        return -1;
                    if (dataX == dataY)
                        return 0;
                }
                if (direction == 1)
                {
                    if (dataX > dataY)
                        return -1;
                    if (dataX < dataY)
                        return 1;
                    if (dataX == dataY)
                        return 0;
                }



                return 0;
            });

            }
    }
}
