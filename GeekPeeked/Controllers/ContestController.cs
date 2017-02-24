using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using GeekPeeked.Models;
using GeekPeeked.Helpers;
using GeekPeeked.Services;
using GeekPeeked.ViewModels;
using GeekPeeked.Repositories.Interfaces;

namespace GeekPeeked.Controllers
{
    public class ContestController : BaseController
    {
        private readonly IContestRespoitory _contestRepository;

        public ContestController(IContestRespoitory contestRepository)
        {
            this._contestRepository = contestRepository;
        }

        public ActionResult Index()
        {
            ContestIndexViewModel viewModel = new ContestIndexViewModel();
            if (viewModel.ActiveContestId != null)
                viewModel.ActiveContest = this._contestRepository.GetContest(Convert.ToInt32(viewModel.ActiveContestId));

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SignUp(int? contestId)
        {
            if (contestId == null)
                contestId = CoreConfiguration.ActiveContestId;

            if (contestId != null)
            {
                ContestSignUpViewModel viewModel = new ContestSignUpViewModel();
                viewModel.ContestId = Convert.ToInt32(contestId);
                viewModel.Contest = this._contestRepository.GetContest(Convert.ToInt32(contestId));
                viewModel.Categories = new List<ContestCategoryViewModel>();

                foreach (var category in viewModel.Contest.AcademyAwardsCategories)
                {
                    ContestCategoryViewModel cat = new ContestCategoryViewModel();
                    cat.CategoryId = category.Id;
                    cat.CategoryTitle = category.CategoryTitle;
                    cat.SortOrder = category.SortOrder;
                    cat.Nominees = new List<ContestNomineeViewModel>();

                    foreach (var nominee in category.AcademyAwardsNominees)
                    {
                        cat.Nominees.Add(new ContestNomineeViewModel() { NomineeId = nominee.Id, NomineeText = nominee.NomineeText, SortOrder = nominee.SortOrder });
                    }

                    viewModel.Categories.Add(cat);
                }

                return View(viewModel);
            }

            Danger("There is no contest to sign up for at this time");

            return RedirectToAction("Index", "Contest");
        }

        [HttpPost]
        public ActionResult SignUp(ContestSignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var contestEntry = new ContestEntry();
                contestEntry.Email = viewModel.Email;
                contestEntry.ContestId = viewModel.ContestId;
                contestEntry.CreatedBy = "ContestController.SignUp()";
                this._contestRepository.AddEntry(contestEntry);

                foreach (var category in viewModel.Categories)
                {
                    if (category.SelectedNomineeId != null)
                    {
                        var selection = new AcademyAwardsContestEntrySelection() { AcademyAwardsCategoryId = category.CategoryId, SelectedAcademyAwardNomineeId = Convert.ToInt32(category.SelectedNomineeId) };
                        this._contestRepository.AddAcademyAwardsNomineeSelectionToContestEntry(contestEntry, selection);
                    }
                }

                this._contestRepository.Save();

                var callbackUrl = string.Format(CoreConfiguration.VerifyContestFormatURL, HttpUtility.UrlEncode(contestEntry.ContestId.ToString()), HttpUtility.UrlEncode(contestEntry.Email), HttpUtility.UrlEncode(contestEntry.VerificationCode));
                EmailService.SendEmail(viewModel.Email, string.Format("{0} - Contest Entry Verification", CoreConfiguration.EmailSubjectTitle), string.Format("Thank you for signing up for our contest.<br /><br />Please click <a href='{0}'>here</a> to verify your email address.<br /><br />Your entry is not valid until you verify your email address.<br /><br />Email: <strong>{1}</strong><br /><br />Verification Code: <strong>{2}</strong><br />", callbackUrl, contestEntry.Email, contestEntry.VerificationCode));

                Success("Successfully submitted your contest entry. Your entry is not complete until you verify your email address by clicking the link when was sent to you", true);

                return RedirectToAction("Index", "Contest");
            }
            else
                Danger("Email is required to sign up for contest", true);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult VerifyEmail(int contestId, string email, string code)
        {
            var contest = this._contestRepository.GetContest(contestId);
            if (contest != null && contest.Id == contestId)
            {
                var contestEntry = this._contestRepository.GetContestEntry(contest.Id, email, code);
                bool result = this._contestRepository.VerifyContestEntry(contest.Id, email, code);
                this._contestRepository.Save();

                if (result)
                {
                    Success("Successfully verified your email address. Your contest entry has been accepted. Good luck!", true);

                    return RedirectToAction("ViewEntry", "Contest", new { contestEntryId = contestEntry.Id });
                }
            }

            Danger("Failed to verify your email. Click the link sent to your email or submit a new contest entry", true);

            return RedirectToAction("Index", "Contest");
        }

        [HttpGet]
        public ActionResult Update(int contestId)
        {
            UpdateContestViewModel viewModel = new UpdateContestViewModel();
            viewModel.ContestId = contestId;
            viewModel.Contest = this._contestRepository.GetContest(contestId);

            return PartialView("_Update", viewModel);
        }

        [HttpPost]
        public ActionResult Update(UpdateContestViewModel viewModel)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Edit", "Contest", new { contestId = viewModel.ContestId, email = viewModel.Email, verificationCode = viewModel.VerificationCode });
            else
                Danger("Failed to find contest entry for that email address and verification code", true);

            return RedirectToAction("Index", "Contest");
        }

        [HttpGet]
        public ActionResult ViewEntry(int contestEntryId)
        {
            ViewContestEntryViewModel viewModel = new ViewContestEntryViewModel();
            viewModel.ContestEntryId = contestEntryId;

            var contestEntry = this._contestRepository.GetContestEntry(contestEntryId);
            viewModel.Contest = this._contestRepository.GetContest(contestEntry.ContestId);

            viewModel.Categories = new List<ContestCategoryViewModel>();

            foreach (var category in viewModel.Contest.AcademyAwardsCategories)
            {
                ContestCategoryViewModel cat = new ContestCategoryViewModel();
                cat.CategoryId = category.Id;
                cat.CategoryTitle = category.CategoryTitle;
                cat.SortOrder = category.SortOrder;
                cat.Nominees = new List<ContestNomineeViewModel>();

                var selection = contestEntry.AcademyAwardsContestEntrySelections.FirstOrDefault(c => c.AcademyAwardsCategoryId == category.Id);
                if(selection != null)
                    cat.SelectedNomineeId = selection.SelectedAcademyAwardNomineeId;

                foreach (var nominee in category.AcademyAwardsNominees)
                {
                    cat.Nominees.Add(new ContestNomineeViewModel() { NomineeId = nominee.Id, NomineeText = nominee.NomineeText, SortOrder = nominee.SortOrder });
                }

                viewModel.Categories.Add(cat);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditEntry(int contestEntryId)
        {
            EditContestEntryViewModel viewModel = new EditContestEntryViewModel();
            viewModel.ContestEntryId = contestEntryId;
            viewModel.ContestEntry = this._contestRepository.GetContestEntry(contestEntryId);
            viewModel.Contest = this._contestRepository.GetContest(viewModel.ContestEntry.ContestId);

            viewModel.Categories = new List<ContestCategoryViewModel>();

            foreach (var category in viewModel.Contest.AcademyAwardsCategories)
            {
                ContestCategoryViewModel cat = new ContestCategoryViewModel();
                cat.CategoryId = category.Id;
                cat.CategoryTitle = category.CategoryTitle;
                cat.SortOrder = category.SortOrder;
                cat.Nominees = new List<ContestNomineeViewModel>();

                var selection = viewModel.ContestEntry.AcademyAwardsContestEntrySelections.FirstOrDefault(c => c.AcademyAwardsCategoryId == category.Id);
                if(selection != null)
                    cat.SelectedNomineeId = selection.SelectedAcademyAwardNomineeId;

                foreach (var nominee in category.AcademyAwardsNominees)
                {
                    cat.Nominees.Add(new ContestNomineeViewModel() { NomineeId = nominee.Id, NomineeText = nominee.NomineeText, SortOrder = nominee.SortOrder });
                }

                viewModel.Categories.Add(cat);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditEntry(EditContestEntryViewModel viewModel)
        {
            var entry = this._contestRepository.GetContestEntry(viewModel.ContestEntryId);

            foreach (var category in viewModel.Categories)
            {
                var entrySelection = this._contestRepository.GetSelection(entry, category.CategoryId);
                if (entrySelection == null && category.SelectedNomineeId != null)
                {
                    var selection = new AcademyAwardsContestEntrySelection() { AcademyAwardsCategoryId = category.CategoryId, SelectedAcademyAwardNomineeId = Convert.ToInt32(category.SelectedNomineeId) };
                    this._contestRepository.AddAcademyAwardsNomineeSelectionToContestEntry(entry, selection);
                }
                else if (entrySelection != null && category.SelectedNomineeId != null)
                    entrySelection.SelectedAcademyAwardNomineeId = Convert.ToInt32(category.SelectedNomineeId);
                else
                    this._contestRepository.RemoveAcademyAwardsNomineeSelectionFromContestEntry(entry, entrySelection);
            }

            this._contestRepository.Save();

            Success("Successfully updated your contest entry", true);

            return RedirectToAction("ViewEntry", "Contest", new { contestEntryId = entry.Id });
        }
    }
}