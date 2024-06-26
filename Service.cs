﻿using System;
using System.Linq;

namespace InterviewProject
{   
    public class Service
    {
        private Data data;
        public Service()
        {
            data = new Data();
        }

        public string A(int id)
        {
            var titles = data.Get(id).Posts.Select(p => p.Title);
            return string.Join(Environment.NewLine, titles);
        }

        public string B(int id)
        {
            return data.Get(id).Posts.OrderByDescending(p => p.Published).First().Title;
        }

        public string C(int id)
        {
            return data.Get(id).Posts.First().Content;
        }

        public Post D(string title)
        {
            return data.GetPost(title);
        }
        public Blog E(int id)
        {
            return data.Get(id);
        }
    }
}
