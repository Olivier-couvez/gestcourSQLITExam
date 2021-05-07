using GestionCoursesXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCoursesXamarin.Extension
{
    public static class Mesextension
    {
        public static enrCourse ToCourseBasique (this Course Course)
        {
            return new enrCourse
            {
                _num = Course.Num,
                _nom = Course.Nom,
                _distance = Course.Distance,
                _lieu = Course.Lieu
            };
        }
        public static Course ToCourse (this enrCourse CourseBasique)
        {
            return new Course
            {
                Num = CourseBasique._num,
                Nom = CourseBasique._nom,
                Distance = CourseBasique._distance,
                Lieu = CourseBasique._lieu
            };
        }
        public static enrCoureur ToCoureurBasique(this Coureur Coureur)
        {
            return new enrCoureur
            {
                _num = Coureur.Num,
                _nom = Coureur.Nom,
                _prenom = Coureur.Prenom,
                _sexe = Coureur.Sexe,
                _age = Coureur.Age,
                _einscrit = Coureur.Einscrit
            };
        }
        public static Coureur ToCoureur(this enrCoureur CoureurBasique)
        {
            return new Coureur
            {
                Num = CoureurBasique._num,
                Nom = CoureurBasique._nom,
                Prenom = CoureurBasique._prenom,
                Sexe = CoureurBasique._sexe,
                Age = CoureurBasique._age,
                Einscrit = CoureurBasique._einscrit
            };
        }

        public static enrInsciption ToInscriptionBasique(this Inscription Inscription)
        {
            return new enrInsciption
            {
                _num = Inscription.Num,
                _idxCoureur = Inscription.IdxCoureur,
                _idxCourse = Inscription.IdxCourse
            };
        }
        public static Inscription ToInscription(this enrInsciption enrInsciptionBasique)
        {
            return new Inscription
            {
                Num = enrInsciptionBasique._num,
                IdxCoureur = enrInsciptionBasique._idxCoureur,
                IdxCourse = enrInsciptionBasique._idxCourse
            };
        }
    }
}
