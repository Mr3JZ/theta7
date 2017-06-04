﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServer
    {
        void Login(User u, IClient client);
        void Logout(User u, IClient client);
        void Register(User user);
        List<Conference> GetConferences();
        Conference GetConference(int id);
        List<Review> GetReviewsByPaper(int paperId);
        List<User> GetSpecialUsers();
        List<User> GetAllUsers();
        void AddReview(int paperId, Review r);
        void AddParticipant(Participant p);
        void NewPaper(Conference c, Paper p);
        void UpdatePaper(Paper p);
        void UpdateConference(Conference c);
        //detaliile despre Payment se calculeaza in repoPayment(succes,nrTickets);
        void NewPayment(Participant p,int paidSum);
        void AddConference(Conference conference);
        void AddMessage(Message message);
        List<Model.Message> GetUserMessages(int userID);
    }
}
