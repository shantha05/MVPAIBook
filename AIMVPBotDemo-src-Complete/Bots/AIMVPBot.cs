// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIMVPBotDemo.BingSearchHelper;
using AIMVPBotDemo.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class AIMVPBot : ActivityHandler
    {
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await SendWelcomeMessageAsync(turnContext, cancellationToken);
        }
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var reply = ProcessInput(turnContext);
            await turnContext.SendActivityAsync(reply, cancellationToken);
            await DisplayOptionsAsync(turnContext, cancellationToken);
        }

        private static async Task DisplayOptionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var card = new HeroCard
            {
                Text = "You can select one of the following choices",
                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.ImBack, title: "1. Bing Web Search", value: "1"),
                    new CardAction(ActionTypes.ImBack, title: "2. Bing Image Search", value: "2"),
                    new CardAction(ActionTypes.ImBack, title: "3. Bing Video Search", value: "3"),
                    new CardAction(ActionTypes.ImBack, title: "4. Bing News Search", value: "4"),
                },
            };

            var reply = MessageFactory.Attachment(card.ToAttachment());
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }

        // Greet the user and give them instructions on how to interact with the bot.
        private static async Task SendWelcomeMessageAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in turnContext.Activity.MembersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(
                        $"Welcome to Bing Search Bot {member.Name}." +
                        $" This bot will introduce you to the capabilities of Bing Search API." +
                        $" Please select an option",
                        cancellationToken: cancellationToken);
                    await DisplayOptionsAsync(turnContext, cancellationToken);
                }
            }
        }

        // Given the input from the message, create the response.
        private static IMessageActivity ProcessInput(ITurnContext turnContext)
        {
            var activity = turnContext.Activity;
            IMessageActivity reply = null;

            reply = HandleSearch(turnContext, activity);

            return reply;
        }
        private static IMessageActivity HandleSearch(ITurnContext turnContext, IMessageActivity activity)
        {
            // Look at the user input, and figure out what kind of attachment to send.
            IMessageActivity reply = null;
            List<ThumbnailCard> cards = null;
            if (activity.Text.StartsWith("1"))
            {
                WebPageList results = WebPagesHelper.BingWebPageSearch(Common.searchText);
                reply = (turnContext.Activity as Activity)
                .CreateReply($"## Reading news about {Common.searchText}");

                cards = WebPagesHelper.GetHeroCardsForWebPages(results);
            }
            else if (activity.Text.StartsWith("2"))
            {
                Images pictures = ImageHelper.BingImagesSearch(Common.searchText);
                reply = (turnContext.Activity as Activity)
                .CreateReply($"## Showing images about {Common.searchText}");

                cards = ImageHelper.GetHeroCardsForImages(pictures);
            }
            else if (activity.Text.StartsWith("3"))
            {
                Videos recordings = VideoHelper.BingVideosSearch(Common.searchText);
                reply = (turnContext.Activity as Activity)
                .CreateReply($"## Showing videos about {Common.searchText}");

                cards = VideoHelper.GetHeroCardsForVideos(recordings);
            }
            else if (activity.Text.StartsWith("4"))
            {
                News articles = NewsHelper.BingNewsSearch(Common.searchText);
                reply = (turnContext.Activity as Activity)
                .CreateReply($"## Reading news about {Common.searchText}");

                cards = NewsHelper.GetHeroCardsForArticles(articles);
            }
            if (cards != null)
            {
                cards.ForEach(card =>
                reply.Attachments.Add(card.ToAttachment()));

                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            }
            return reply;
        }
    }
}
