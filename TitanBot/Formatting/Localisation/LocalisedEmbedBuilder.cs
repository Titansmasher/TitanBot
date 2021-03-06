﻿using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using TitanBot.Formatting.Interfaces;
using TitanBot.Replying;

namespace TitanBot.Formatting
{
    public class LocalisedEmbedBuilder : ILocalisable<EmbedBuilder>
    {

        public ILocalisable<string> Title { get; set; }
        public ILocalisable<string> Description { get; set; }
        public ILocalisable<string> Url { get; set; }
        public ILocalisable<string> ThumbnailUrl { get; set; }
        public ILocalisable<string> ImageUrl { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public Color? Color { get; set; }

        public LocalisedAuthorBuilder Author { get; set; }
        public LocalisedFooterBuilder Footer { get; set; }
        private List<LocalisedFieldBuilder> _fields { get; set; } = new List<LocalisedFieldBuilder>();
        public List<LocalisedFieldBuilder> Fields
        {
            get => _fields;
            set
            {
                if (value == null) throw new ArgumentNullException("Cannot set an embed builders' fields collection to null", nameof(Fields));
                if (value.Count > EmbedBuilder.MaxFieldCount) throw new ArgumentException($"Field count must be less than or equal to {EmbedBuilder.MaxFieldCount}.", nameof(Fields));
                _fields = value;
            }
        }

        public LocalisedEmbedBuilder WithTitle(ILocalisable<string> title)
        {
            Title = title;
            return this;
        }

        public LocalisedEmbedBuilder WithDescription(ILocalisable<string> description)
        {
            Description = description;
            return this;
        }

        public LocalisedEmbedBuilder WithUrl(ILocalisable<string> url)
        {
            Url = url;
            return this;
        }

        public LocalisedEmbedBuilder WithThumbnailUrl(ILocalisable<string> thumbnailUrl)
        {
            ThumbnailUrl = thumbnailUrl;
            return this;
        }

        public LocalisedEmbedBuilder WithImageUrl(ILocalisable<string> imageUrl)
        {
            ImageUrl = imageUrl;
            return this;
        }

        public LocalisedEmbedBuilder WithCurrentTimestamp()
        {
            Timestamp = DateTimeOffset.UtcNow;
            return this;
        }
        public LocalisedEmbedBuilder WithTimestamp(DateTimeOffset? dateTimeOffset)
        {
            Timestamp = dateTimeOffset;
            return this;
        }
        public LocalisedEmbedBuilder WithColor(Color? color)
        {
            Color = color;
            return this;
        }

        public LocalisedEmbedBuilder WithAuthor(LocalisedAuthorBuilder author)
        {
            Author = author;
            return this;
        }
        public LocalisedEmbedBuilder WithAuthor(IUser author)
        {
            Author = LocalisedAuthorBuilder.FromUser(author);
            return this;
        }
        public LocalisedEmbedBuilder WithAuthor(Action<LocalisedAuthorBuilder> action)
        {
            var author = new LocalisedAuthorBuilder();
            action(author);
            Author = author;
            return this;
        }

        public LocalisedEmbedBuilder WithFooter(LocalisedFooterBuilder footer)
        {
            Footer = footer;
            return this;
        }
        public LocalisedEmbedBuilder WithFooter(Action<LocalisedFooterBuilder> action)
        {
            var footer = new LocalisedFooterBuilder();
            action(footer);
            Footer = footer;
            return this;
        }

        public LocalisedEmbedBuilder AddField(ILocalisable<string> name, ILocalisable<string> value, bool inline = false)
            => AddField(new LocalisedFieldBuilder { Name = name, Value = value, IsInline = inline });
        public LocalisedEmbedBuilder AddInlineField(ILocalisable<string> name, ILocalisable<string> value)
            => AddField(name, value, true);
        public LocalisedEmbedBuilder AddField(LocalisedFieldBuilder field)
        {
            if (Fields.Count >= EmbedBuilder.MaxFieldCount)
            {
                throw new ArgumentException($"Field count must be less than or equal to {EmbedBuilder.MaxFieldCount}.", nameof(field));
            }

            Fields.Add(field);
            return this;
        }
        public LocalisedEmbedBuilder AddField(Action<LocalisedFieldBuilder> action)
        {
            var field = new LocalisedFieldBuilder();
            action(field);
            return AddField(field);
        }
        public LocalisedEmbedBuilder AddInlineField(Action<LocalisedFieldBuilder> action)
        {
            var field = new LocalisedFieldBuilder().WithIsInline(true);
            action(field);
            return AddField(field);
        }

        object ILocalisable.Localise(ITextResourceCollection textResource)
            => Localise(textResource);
        public EmbedBuilder Localise(ITextResourceCollection textResource)
            => new EmbedBuilder
            {
                Author = Author?.Localise(textResource),
                Color = Color,
                Description = Description?.Localise(textResource),
                Fields = Fields.Select(f => f?.Localise(textResource)).Where(f => f != null).ToList(),
                Footer = Footer?.Localise(textResource),
                ImageUrl = ImageUrl?.Localise(textResource),
                ThumbnailUrl = ThumbnailUrl?.Localise(textResource),
                Timestamp = Timestamp,
                Title = Title?.Localise(textResource),
                Url = Url?.Localise(textResource)
            };

        public static implicit operator LocalisedEmbedBuilder(EmbedBuilder builder)
            => builder == null ? null : new LocalisedEmbedBuilder
            {
                Author = builder?.Author,
                Color = builder?.Color,
                Description = (RawString)builder?.Description,
                Fields = builder?.Fields?.Select(f => (LocalisedFieldBuilder)f).ToList(),
                Footer = builder?.Footer,
                ImageUrl = (RawString)builder?.ImageUrl,
                ThumbnailUrl = (RawString)builder?.ThumbnailUrl,
                Timestamp = builder?.Timestamp,
                Title = (RawString)builder?.Title,
                Url = (RawString)builder?.Url
            };

        #region WithX Overloads
        public LocalisedEmbedBuilder WithRawTitle(string rawText)
            => WithTitle(new RawString(rawText));
        public LocalisedEmbedBuilder WithTitle(string key)
            => WithTitle(new LocalisedString(key));
        public LocalisedEmbedBuilder WithTitle(string key, ReplyType replyType)
            => WithTitle(new LocalisedString(key, replyType));
        public LocalisedEmbedBuilder WithTitle(string key, params object[] values)
            => WithTitle(new LocalisedString(key, values));
        public LocalisedEmbedBuilder WithTitle(string key, ReplyType replyType, params object[] values)
            => WithTitle(new LocalisedString(key, replyType, values));

        public LocalisedEmbedBuilder WithRawDescription(string rawText)
            => WithDescription(new RawString(rawText));
        public LocalisedEmbedBuilder WithDescription(string key)
            => WithDescription(new LocalisedString(key));
        public LocalisedEmbedBuilder WithDescription(string key, ReplyType replyType)
            => WithDescription(new LocalisedString(key, replyType));
        public LocalisedEmbedBuilder WithDescription(string key, params object[] values)
            => WithDescription(new LocalisedString(key, values));
        public LocalisedEmbedBuilder WithDescription(string key, ReplyType replyType, params object[] values)
            => WithDescription(new LocalisedString(key, replyType, values));

        public LocalisedEmbedBuilder WithRawUrl(string rawText)
            => WithUrl(new RawString(rawText));
        public LocalisedEmbedBuilder WithUrl(string key)
            => WithUrl(new LocalisedString(key));
        public LocalisedEmbedBuilder WithUrl(string key, ReplyType replyType)
            => WithUrl(new LocalisedString(key, replyType));
        public LocalisedEmbedBuilder WithUrl(string key, params object[] values)
            => WithUrl(new LocalisedString(key, values));
        public LocalisedEmbedBuilder WithUrl(string key, ReplyType replyType, params object[] values)
            => WithUrl(new LocalisedString(key, replyType, values));

        public LocalisedEmbedBuilder WithRawThumbnailUrl(string rawText)
            => WithThumbnailUrl(new RawString(rawText));
        public LocalisedEmbedBuilder WithThumbnailUrl(string key)
            => WithThumbnailUrl(new LocalisedString(key));
        public LocalisedEmbedBuilder WithThumbnailUrl(string key, ReplyType replyType)
            => WithThumbnailUrl(new LocalisedString(key, replyType));
        public LocalisedEmbedBuilder WithThumbnailUrl(string key, params object[] values)
            => WithThumbnailUrl(new LocalisedString(key, values));
        public LocalisedEmbedBuilder WithThumbnailUrl(string key, ReplyType replyType, params object[] values)
            => WithThumbnailUrl(new LocalisedString(key, replyType, values));

        public LocalisedEmbedBuilder WithRawImageUrl(string rawText)
            => WithImageUrl(new RawString(rawText));
        public LocalisedEmbedBuilder WithImageUrl(string key)
            => WithImageUrl(new LocalisedString(key));
        public LocalisedEmbedBuilder WithImageUrl(string key, ReplyType replyType)
            => WithImageUrl(new LocalisedString(key, replyType));
        public LocalisedEmbedBuilder WithImageUrl(string key, params object[] values)
            => WithImageUrl(new LocalisedString(key, values));
        public LocalisedEmbedBuilder WithImageUrl(string key, ReplyType replyType, params object[] values)
            => WithImageUrl(new LocalisedString(key, replyType, values));
        #endregion
    }

    public class LocalisedAuthorBuilder : ILocalisable<EmbedAuthorBuilder>
    {
        public ILocalisable<string> Name { get; set; }
        public ILocalisable<string> Url { get; set; }
        public ILocalisable<string> IconUrl { get; set; }

        public LocalisedAuthorBuilder WithName(ILocalisable<string> name)
        {
            Name = name;
            return this;
        }
        public LocalisedAuthorBuilder WithUrl(ILocalisable<string> url)
        {
            Url = url;
            return this;
        }
        public LocalisedAuthorBuilder WithIconUrl(ILocalisable<string> iconUrl)
        {
            IconUrl = iconUrl;
            return this;
        }

        object ILocalisable.Localise(ITextResourceCollection textResource)
            => Localise(textResource);
        public EmbedAuthorBuilder Localise(ITextResourceCollection textResource)
            => new EmbedAuthorBuilder
            {
                Name = Name?.Localise(textResource),
                Url = Url?.Localise(textResource),
                IconUrl = IconUrl?.Localise(textResource)
            };

        public static implicit operator LocalisedAuthorBuilder(EmbedAuthorBuilder builder)
            => builder == null ? null : new LocalisedAuthorBuilder
            {
                IconUrl = (RawString)builder.IconUrl,
                Name = (RawString)builder.Name,
                Url = (RawString)builder.Url
            };

        public static LocalisedAuthorBuilder FromUser(IUser user)
            => new LocalisedAuthorBuilder
            {
                IconUrl = (RawString)user.GetAvatarUrl(),
                Name = (RawString)$"{user.Username}#{user.Discriminator}"
            };

        #region WithX Overloads
        public LocalisedAuthorBuilder WithRawName(string rawText)
            => WithName(new RawString(rawText));
        public LocalisedAuthorBuilder WithName(string key)
            => WithName(new LocalisedString(key));
        public LocalisedAuthorBuilder WithName(string key, ReplyType replyType)
            => WithName(new LocalisedString(key, replyType));
        public LocalisedAuthorBuilder WithName(string key, params object[] values)
            => WithName(new LocalisedString(key, values));
        public LocalisedAuthorBuilder WithName(string key, ReplyType replyType, params object[] values)
            => WithName(new LocalisedString(key, replyType, values));

        public LocalisedAuthorBuilder WithRawUrl(string rawText)
            => WithUrl(new RawString(rawText));
        public LocalisedAuthorBuilder WithUrl(string key)
            => WithUrl(new LocalisedString(key));
        public LocalisedAuthorBuilder WithUrl(string key, ReplyType replyType)
            => WithUrl(new LocalisedString(key, replyType));
        public LocalisedAuthorBuilder WithUrl(string key, params object[] values)
            => WithUrl(new LocalisedString(key, values));
        public LocalisedAuthorBuilder WithUrl(string key, ReplyType replyType, params object[] values)
            => WithUrl(new LocalisedString(key, replyType, values));

        public LocalisedAuthorBuilder WithRawIconUrl(string rawText)
            => WithIconUrl(new RawString(rawText));
        public LocalisedAuthorBuilder WithIconUrl(string key)
            => WithIconUrl(new LocalisedString(key));
        public LocalisedAuthorBuilder WithIconUrl(string key, ReplyType replyType)
            => WithIconUrl(new LocalisedString(key, replyType));
        public LocalisedAuthorBuilder WithIconUrl(string key, params object[] values)
            => WithIconUrl(new LocalisedString(key, values));
        public LocalisedAuthorBuilder WithIconUrl(string key, ReplyType replyType, params object[] values)
            => WithIconUrl(new LocalisedString(key, replyType, values));
        #endregion
    }

    public class LocalisedFooterBuilder : ILocalisable<EmbedFooterBuilder>
    {
        public ILocalisable<string> Text { get; set; }
        public ILocalisable<string> IconUrl { get; set; }

        public LocalisedFooterBuilder WithText(ILocalisable<string> text)
        {
            Text = text;
            return this;
        }
        public LocalisedFooterBuilder WithIconUrl(ILocalisable<string> iconUrl)
        {
            IconUrl = iconUrl;
            return this;
        }

        object ILocalisable.Localise(ITextResourceCollection textResource)
            => Localise(textResource);
        public EmbedFooterBuilder Localise(ITextResourceCollection textResource)
            => new EmbedFooterBuilder
            {
                Text = Text?.Localise(textResource),
                IconUrl = IconUrl?.Localise(textResource)
            };

        public static implicit operator LocalisedFooterBuilder(EmbedFooterBuilder builder)
            => builder == null ? null : new LocalisedFooterBuilder
            {
                IconUrl = (RawString)builder.IconUrl,
                Text = (RawString)builder.Text
            };

        #region WithX Overloads
        public LocalisedFooterBuilder WithRawText(string rawText)
            => WithText(new RawString(rawText));
        public LocalisedFooterBuilder WithText(string key)
            => WithText(new LocalisedString(key));
        public LocalisedFooterBuilder WithText(string key, ReplyType replyType)
            => WithText(new LocalisedString(key, replyType));
        public LocalisedFooterBuilder WithText(string key, params object[] values)
            => WithText(new LocalisedString(key, values));
        public LocalisedFooterBuilder WithText(string key, ReplyType replyType, params object[] values)
            => WithText(new LocalisedString(key, replyType, values));

        public LocalisedFooterBuilder WithRawIconUrl(string rawText)
            => WithIconUrl(new RawString(rawText));
        public LocalisedFooterBuilder WithIconUrl(string key)
            => WithIconUrl(new LocalisedString(key));
        public LocalisedFooterBuilder WithIconUrl(string key, ReplyType replyType)
            => WithIconUrl(new LocalisedString(key, replyType));
        public LocalisedFooterBuilder WithIconUrl(string key, params object[] values)
            => WithIconUrl(new LocalisedString(key, values));
        public LocalisedFooterBuilder WithIconUrl(string key, ReplyType replyType, params object[] values)
            => WithIconUrl(new LocalisedString(key, replyType, values));
        #endregion
    }

    public class LocalisedFieldBuilder : ILocalisable<EmbedFieldBuilder>
    {
        public ILocalisable<string> Name { get; set; }
        public ILocalisable<string> Value { get; set; }
        public bool IsInline { get; set; }

        public LocalisedFieldBuilder WithName(ILocalisable<string> name)
        {
            Name = name;
            return this;
        }
        public LocalisedFieldBuilder WithValue(ILocalisable<string> value)
        {
            Value = value;
            return this;
        }

        public LocalisedFieldBuilder WithIsInline(bool isInline)
        {
            IsInline = isInline;
            return this;
        }

        object ILocalisable.Localise(ITextResourceCollection textResource)
            => Localise(textResource);
        public EmbedFieldBuilder Localise(ITextResourceCollection textResource)
            => new EmbedFieldBuilder
            {
                Name = Name?.Localise(textResource),
                Value = Value?.Localise(textResource),
                IsInline = IsInline
            };

        public static implicit operator LocalisedFieldBuilder(EmbedFieldBuilder builder)
            => builder == null ? null : new LocalisedFieldBuilder
            {
                IsInline = builder.IsInline,
                Name = (RawString)builder.Name,
                Value = (RawString)builder.Value.ToString()
            };

        #region WithX Overloads
        public LocalisedFieldBuilder WithRawValue(string rawText)
            => WithValue(new RawString(rawText));
        public LocalisedFieldBuilder WithValue(object value)
            => WithValue(new LocalisedString(value));
        public LocalisedFieldBuilder WithValue(Func<ITextResourceCollection, string> localisationFunc)
            => WithValue(new DynamicString(localisationFunc));
        public LocalisedFieldBuilder WithValue(string key)
            => WithValue(new LocalisedString(key));
        public LocalisedFieldBuilder WithValue(string key, ReplyType replyType)
            => WithValue(new LocalisedString(key, replyType));
        public LocalisedFieldBuilder WithValue(string key, params object[] values)
            => WithValue(new LocalisedString(key, values));
        public LocalisedFieldBuilder WithValue(string key, ReplyType replyType, params object[] values)
            => WithValue(new LocalisedString(key, replyType, values));
        public LocalisedFieldBuilder WithValues<T>(string separator, IEnumerable<T> values)
            => WithValues(separator, values.ToArray());
        public LocalisedFieldBuilder WithValues<T>(string separator, T[] values)
            => WithValue(LocalisedString.Join(separator, values.Cast<object>().ToArray()));

        public LocalisedFieldBuilder WithRawName(string rawText)
            => WithName(new RawString(rawText));
        public LocalisedFieldBuilder WithName(Func<ITextResourceCollection, string> localisationFunc)
            => WithName(new DynamicString(localisationFunc));
        public LocalisedFieldBuilder WithName(string key)
            => WithName(new LocalisedString(key));
        public LocalisedFieldBuilder WithName(string key, ReplyType replyType)
            => WithName(new LocalisedString(key, replyType));
        public LocalisedFieldBuilder WithName(string key, params object[] values)
            => WithName(new LocalisedString(key, values));
        public LocalisedFieldBuilder WithName(string key, ReplyType replyType, params object[] values)
            => WithName(new LocalisedString(key, replyType, values));
        #endregion
    }
}
