using System;
using System.Linq;
using System.Reactive.Linq;

namespace RandomStringGeneratorFromKatakanaAndHiragana
{
    class Program
    {
        static void Main(string[] args)
        {
            // ひらがなのストリームを作る

            var hiraganas = Observable.Generate(
                    'あ',
                    hiragana => hiragana <= 'ん',
                    hiragana => ++hiragana,
                    hiragana => hiragana)
                    .ToEnumerable();

            // カタカナのストリームを作る

            var katakanas = Observable.Generate(
                    'ア',
                    katakana => katakana <= 'ン',
                    katakana => ++katakana,
                    katakana => katakana)
                    .ToEnumerable();

            // 合体

            var concatedCollection = hiraganas
                .Concat(katakanas);

            // コレクションからランダムに20文字取り出す

            foreach (var _ in Enumerable.Range(0, 20))
            {
                var fetchedCaracter = concatedCollection
                    .ElementAt(new Random().Next(concatedCollection.Count()));

                Console.Write(fetchedCaracter);
            }

            Console.WriteLine();
        }
    }
}

