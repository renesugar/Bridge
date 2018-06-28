using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    [Bridge.Convention(Member = Bridge.ConventionMember.Field | Bridge.ConventionMember.Method, Notation = Bridge.Notation.CamelCase)]
    [Bridge.External]
    [Bridge.Name("System.Linq.Enumerable")]
    public static class Enumerable
    {
        /// <summary>
        /// Applies an accumulator function over a sequence.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to aggregate over.
        /// </param>
        /// <param name="func">
        /// An accumulator function to be invoked on each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The final accumulator value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or func is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).aggregate({func})")]
        public static extern TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func);

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value
        /// is used as the initial accumulator value.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to aggregate over.
        /// </param>
        /// <param name="seed">
        /// The initial accumulator value.
        /// </param>
        /// <param name="func">
        /// An accumulator function to be invoked on each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TAccumulate">
        /// The type of the accumulator value.
        /// </typeparam>
        /// <returns>
        /// The final accumulator value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or func is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).aggregate({seed}, {func})")]
        public static extern TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func);

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value
        /// is used as the initial accumulator value, and the specified function is used
        /// to select the result value.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to aggregate over.
        /// </param>
        /// <param name="seed">
        /// The initial accumulator value.
        /// </param>
        /// <param name="func">
        /// An accumulator function to be invoked on each element.
        /// </param>
        /// <param name="resultSelector">
        /// A function to transform the final accumulator value into the result value.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TAccumulate">
        /// The type of the accumulator value.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the resulting value.
        /// </typeparam>
        /// <returns>
        /// The transformed final accumulator value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or func or resultSelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).aggregate({seed}, {func}, {resultSelector})")]
        public static extern TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector);

        /// <summary>
        /// Determines whether all elements of a sequence satisfy a condition.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements to
        /// apply the predicate to.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// true if every element of the source sequence passes the test in the specified
        /// predicate, or if the sequence is empty; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).all({predicate})")]
        public static extern bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Determines whether a sequence contains any elements.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.Generic.IEnumerable&lt;T&gt; to check for emptiness.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// true if the source sequence contains any elements; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).any()")]
        public static extern bool Any<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to apply the
        /// predicate to.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// true if any elements in the source sequence pass the test in the specified
        /// predicate; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).any({predicate})")]
        public static extern bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Returns the input typed as System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </summary>
        /// <param name="source">
        /// The sequence to type as System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The input sequence typed as System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </returns>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{source}")]
        public static extern EnumerableInstance<TSource> AsEnumerable<TSource>(this EnumerableInstance<TSource> source);

        /// <summary>
        /// Returns the input typed as System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </summary>
        /// <param name="source">
        /// The sequence to type as System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The input sequence typed as System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </returns>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{source}")]
        public static extern IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Decimal values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableAverage(System.Decimal.Zero)")]
        public static extern decimal? Average(this EnumerableInstance<decimal?> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Decimal values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage(System.Decimal.Zero)")]
        public static extern decimal? Average(this IEnumerable<decimal?> source);

        /// <summary>
        /// Computes the average of a sequence of System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Decimal values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.average(System.Decimal.Zero)")]
        public static extern decimal Average(this EnumerableInstance<decimal> source);

        /// <summary>
        /// Computes the average of a sequence of System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Decimal values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average(System.Decimal.Zero)")]
        public static extern decimal Average(this IEnumerable<decimal> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Double values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableAverage()")]
        public static extern double? Average(this EnumerableInstance<double?> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Double values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage()")]
        public static extern double? Average(this IEnumerable<double?> source);

        /// <summary>
        /// Computes the average of a sequence of System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Double values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.average()")]
        public static extern double Average(this EnumerableInstance<double> source);

        /// <summary>
        /// Computes the average of a sequence of System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Double values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average()")]
        public static extern double Average(this IEnumerable<double> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Single values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableAverage()")]
        public static extern float? Average(this EnumerableInstance<float?> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Single values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage()")]
        public static extern float? Average(this IEnumerable<float?> source);

        /// <summary>
        /// Computes the average of a sequence of System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Single values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.average()")]
        public static extern float Average(this EnumerableInstance<float> source);

        /// <summary>
        /// Computes the average of a sequence of System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Single values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average()")]
        public static extern float Average(this IEnumerable<float> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int32 values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableAverage()")]
        public static extern double? Average(this EnumerableInstance<int?> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int32 values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage()")]
        public static extern double? Average(this IEnumerable<int?> source);

        /// <summary>
        /// Computes the average of a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int32 values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.average()")]
        public static extern double Average(this EnumerableInstance<int> source);

        /// <summary>
        /// Computes the average of a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int32 values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average()")]
        public static extern double Average(this IEnumerable<int> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int64 values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableAverage()")]
        public static extern double? Average(this EnumerableInstance<long?> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int64 values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage()")]
        public static extern double? Average(this IEnumerable<long?> source);

        /// <summary>
        /// Computes the average of a sequence of System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int64 values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.average()")]
        public static extern double Average(this EnumerableInstance<long> source);

        /// <summary>
        /// Computes the average of a sequence of System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int64 values to calculate the average of.
        /// </param>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average()")]
        public static extern double Average(this IEnumerable<long> source);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Decimal values that
        /// are obtained by invoking a transform function on each element of the input
        /// sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage({selector}, System.Decimal.Zero)")]
        public static extern decimal? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector);

        /// <summary>
        /// Computes the average of a sequence of System.Decimal values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate an average.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average({selector}, System.Decimal.Zero)")]
        public static extern decimal Average<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Double values that
        /// are obtained by invoking a transform function on each element of the input
        /// sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage({selector})")]
        public static extern double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector);

        /// <summary>
        /// Computes the average of a sequence of System.Double values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average({selector})")]
        public static extern double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Single values that
        /// are obtained by invoking a transform function on each element of the input
        /// sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage({selector})")]
        public static extern float? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector);

        /// <summary>
        /// Computes the average of a sequence of System.Single values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average({selector})")]
        public static extern float Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Int32 values that are
        /// obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage({selector})")]
        public static extern double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector);

        /// <summary>
        /// Computes the average of a sequence of System.Int32 values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average({selector})")]
        public static extern double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);

        /// <summary>
        /// Computes the average of a sequence of nullable System.Int64 values that are
        /// obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values, or null if the source sequence is
        /// empty or contains only values that are null.
        /// </returns>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableAverage({selector})")]
        public static extern double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector);

        /// <summary>
        /// Computes the average of a sequence of System.Int64 values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to calculate the average of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The average of the sequence of values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).average({selector})")]
        public static extern double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);

        /// <summary>
        /// Casts the elements of an System.Collections.IEnumerable to the specified
        /// type.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.IEnumerable that contains the elements to be cast
        /// to type TResult.
        /// </param>
        /// <typeparam name="TResult">
        /// The type to cast the elements of source to.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains each element of
        /// the source sequence cast to the specified type.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// An element in the sequence cannot be cast to type TResult.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).select(function (x) { return Bridge.cast(x, {TResult}); })")]
        public static extern EnumerableInstance<TResult> Cast<TResult>(this IEnumerable source);

        /// <summary>
        /// Concatenates two sequences.
        /// </summary>
        /// <param name="first">
        /// The first sequence to concatenate.
        /// </param>
        /// <param name="second">
        /// The sequence to concatenate to the first sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the concatenated
        /// elements of the two input sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({first}).concat({second})")]
        public static extern EnumerableInstance<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);

        /// <summary>
        /// Determines whether a sequence contains a specified element by using the default
        /// equality comparer.
        /// </summary>
        /// <param name="source">
        /// A sequence in which to locate a value.
        /// </param>
        /// <param name="value">
        /// The value to locate in the sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// true if the source sequence contains an element that has the specified value;
        /// otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).contains({value})")]
        public static extern bool Contains<TSource>(this IEnumerable<TSource> source, TSource value);

        /// <summary>
        /// Determines whether a sequence contains a specified element by using a specified
        /// System.Collections.Generic.IEqualityComparer&lt;T&gt;.
        /// </summary>
        /// <param name="source">
        /// A sequence in which to locate a value.
        /// </param>
        /// <param name="value">
        /// The value to locate in the sequence.
        /// </param>
        /// <param name="comparer">
        /// An equality comparer to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// true if the source sequence contains an element that has the specified value;
        /// otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).contains({value}, {comparer})")]
        public static extern bool Contains<TSource>(this IEnumerable<TSource> source, TSource value,
            IEqualityComparer<TSource> comparer);

        /// <summary>
        /// Returns the number of elements in a sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence that contains elements to be counted.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The number of elements in the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The number of elements in source is larger than System.Int32.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).count()")]
        public static extern int Count<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns a number that represents how many elements in the specified sequence
        /// satisfy a condition.
        /// </summary>
        /// <param name="source">
        /// A sequence that contains elements to be tested and counted.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A number that represents how many elements in the sequence satisfy the condition
        /// in the predicate function.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The number of elements in source is larger than System.Int32.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).count({predicate})")]
        public static extern int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Returns the elements of the specified sequence or the type parameter's default
        /// value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <param name="source">
        /// The sequence to return a default value for if it is empty.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; object that contains the default
        /// value for the TSource type if source is empty; otherwise, source.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).defaultIfEmpty({TSource:default})")]
        public static extern EnumerableInstance<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns the elements of the specified sequence or the specified value in
        /// a singleton collection if the sequence is empty.
        /// </summary>
        /// <param name="source">
        /// The sequence to return the specified value for if it is empty.
        /// </param>
        /// <param name="defaultValue">
        /// The value to return if the sequence is empty.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains defaultValue if
        /// source is empty; otherwise, source.
        /// </returns>
        [Bridge.Template("System.Linq.Enumerable.from({source}).defaultIfEmpty({defaultValue})")]
        public static extern EnumerableInstance<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source,
            TSource defaultValue);

        /// <summary>
        /// Returns distinct elements from a sequence by using the default equality comparer
        /// to compare values.
        /// </summary>
        /// <param name="source">
        /// The sequence to remove duplicate elements from.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains distinct elements
        /// from the source sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).distinct()")]
        public static extern EnumerableInstance<TSource> Distinct<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified System.Collections.Generic.IEqualityComparer&lt;T&gt;
        /// to compare values.
        /// </summary>
        /// <param name="source">
        /// The sequence to remove duplicate elements from.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains distinct elements
        /// from the source sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).distinct({comparer})")]
        public static extern EnumerableInstance<TSource> Distinct<TSource>(this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer);

        /// <summary>
        /// Returns the element at a specified index in a sequence.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return an element from.
        /// </param>
        /// <param name="index">
        /// The zero-based index of the element to retrieve.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The element at the specified position in the source sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// index is less than 0 or greater than or equal to the number of elements in
        /// source.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).elementAt({index})")]
        public static extern TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index);

        /// <summary>
        /// Returns the element at a specified index in a sequence or a default value
        /// if the index is out of range.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return an element from.
        /// </param>
        /// <param name="index">
        /// The zero-based index of the element to retrieve.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// default(TSource) if the index is outside the bounds of the source sequence;
        /// otherwise, the element at the specified position in the source sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).elementAtOrDefault({index}, {TSource:default})")]
        public static extern TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index);

        /// <summary>
        /// Returns an empty System.Collections.Generic.IEnumerable&lt;T&gt; that has the specified
        /// type argument.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type to assign to the type parameter of the returned generic System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </typeparam>
        /// <returns>
        /// An empty System.Collections.Generic.IEnumerable&lt;T&gt; whose type argument is
        /// TResult.
        /// </returns>
        public static extern EnumerableInstance<TResult> Empty<TResult>();

        /// <summary>
        /// Produces the set difference of two sequences by using the default equality
        /// comparer to compare values.
        /// </summary>
        /// <param name="first">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements that are not
        /// also in second will be returned.
        /// </param>
        /// <param name="second">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements that also occur
        /// in the first sequence will cause those elements to be removed from the returned
        /// sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the set difference of the elements of two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({first}).except({second})")]
        public static extern EnumerableInstance<TSource> Except<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second);

        /// <summary>
        /// Produces the set difference of two sequences by using the specified System.Collections.Generic.IEqualityComparer&lt;T&gt;
        /// to compare values.
        /// </summary>
        /// <param name="first">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements that are not
        /// also in second will be returned.
        /// </param>
        /// <param name="second">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements that also occur
        /// in the first sequence will cause those elements to be removed from the returned
        /// sequence.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the set difference of the elements of two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({first}).except({second}, {comparer})")]
        public static extern EnumerableInstance<TSource> Except<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);

        /// <summary>
        /// Returns the first element of a sequence.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.Generic.IEnumerable&lt;T&gt; to return the first element
        /// of.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The first element in the specified sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// The source sequence is empty.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).first()")]
        public static extern TSource First<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns the first element in a sequence that satisfies a specified condition.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return an element from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The first element in the sequence that passes the test in the specified predicate
        /// function.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// No element satisfies the condition in predicate.-or-The source sequence is
        /// empty.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).first({predicate})")]
        public static extern TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence
        /// contains no elements.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.Generic.IEnumerable&lt;T&gt; to return the first element
        /// of.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// default(TSource) if source is empty; otherwise, the first element in source.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).firstOrDefault(null, {TSource:default})")]
        public static extern TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or a
        /// default value if no such element is found.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return an element from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// default(TSource) if source is empty or if no element passes the test specified
        /// by predicate; otherwise, the first element in source that passes the test
        /// specified by predicate.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).firstOrDefault({predicate}, {TSource:default})")]
        public static extern TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of
        /// TKey, TSource)) in Visual Basic where each System.Linq.IGrouping&lt;TKey,TElement&gt;
        /// object contains a sequence of objects and a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).groupBy({keySelector})")]
        public static extern EnumerableInstance<Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector);

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result value from each group.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result value returned by resultSelector.
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type TResult where each element represents a
        /// projection over a group and its key.
        /// </returns>
        [Bridge.Template("System.Linq.Enumerable.from({source}).groupBy({keySelector}, null, {resultSelector})")]
        public static extern EnumerableInstance<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector);

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and projects the elements for each group by using a specified function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="elementSelector">
        /// A function to map each source element to an element in the System.Linq.IGrouping&lt;TKey,TElement&gt;.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the elements in the System.Linq.IGrouping&lt;TKey,TElement&gt;.
        /// </typeparam>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; in C# or IEnumerable(Of IGrouping(Of
        /// TKey, TElement)) in Visual Basic where each System.Linq.IGrouping&lt;TKey,TElement&gt;
        /// object contains a collection of objects of type TElement and a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).groupBy({keySelector}, {elementSelector})")]
        public static extern EnumerableInstance<Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and compares the keys by using a specified comparer.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of
        /// TKey, TSource)) in Visual Basic where each System.Linq.IGrouping&lt;TKey,TElement&gt;
        /// object contains a collection of objects and a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).groupBy({keySelector}, null, null, {comparer})")]
        public static extern EnumerableInstance<Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key. The keys are compared
        /// by using a specified comparer.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result value from each group.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare keys with.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result value returned by resultSelector.
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type TResult where each element represents a
        /// projection over a group and its key.
        /// </returns>
        [Bridge.Template("System.Linq.Enumerable.from({source}).groupBy({keySelector}, null, {resultSelector}, {comparer})")]
        public static extern EnumerableInstance<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key. The elements of each
        /// group are projected by using a specified function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="elementSelector">
        /// A function to map each source element to an element in an System.Linq.IGrouping&lt;TKey,TElement&gt;.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result value from each group.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the elements in each System.Linq.IGrouping&lt;TKey,TElement&gt;.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result value returned by resultSelector.
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type TResult where each element represents a
        /// projection over a group and its key.
        /// </returns>
        [Bridge.Template("System.Linq.Enumerable.from({source}).groupBy({keySelector}, {elementSelector}, {resultSelector})")]
        public static extern EnumerableInstance<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector);

        /// <summary>
        /// Groups the elements of a sequence according to a key selector function. The
        /// keys are compared by using a comparer and each group's elements are projected
        /// by using a specified function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="elementSelector">
        /// A function to map each source element to an element in an System.Linq.IGrouping&lt;TKey,TElement&gt;.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the elements in the System.Linq.IGrouping&lt;TKey,TElement&gt;.
        /// </typeparam>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; in C# or IEnumerable(Of IGrouping(Of
        /// TKey, TElement)) in Visual Basic where each System.Linq.IGrouping&lt;TKey,TElement&gt;
        /// object contains a collection of objects of type TElement and a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).groupBy({keySelector}, {elementSelector}, null, {comparer})")]
        public static extern EnumerableInstance<Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key. Key values are compared
        /// by using a specified comparer, and the elements of each group are projected
        /// by using a specified function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="elementSelector">
        /// A function to map each source element to an element in an System.Linq.IGrouping&lt;TKey,TElement&gt;.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result value from each group.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare keys with.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the elements in each System.Linq.IGrouping&lt;TKey,TElement&gt;.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result value returned by resultSelector.
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type TResult where each element represents a
        /// projection over a group and its key.
        /// </returns>
        [Bridge.Template("System.Linq.Enumerable.from({source}).groupBy({keySelector}, {elementSelector}, {resultSelector}, {comparer})")]
        public static extern EnumerableInstance<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Correlates the elements of two sequences based on equality of keys and groups
        /// the results. The default equality comparer is used to compare keys.
        /// </summary>
        /// <param name="outer">
        /// The first sequence to join.
        /// </param>
        /// <param name="inner">
        /// The sequence to join to the first sequence.
        /// </param>
        /// <param name="outerKeySelector">
        /// A function to extract the join key from each element of the first sequence.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to extract the join key from each element of the second sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from an element from the first sequence
        /// and a collection of matching elements from the second sequence.
        /// </param>
        /// <typeparam name="TOuter">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TInner">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by the key selector functions.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains elements of type
        /// TResult that are obtained by performing a grouped join on two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// outer or inner or outerKeySelector or innerKeySelector or resultSelector
        /// is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({outer}).groupJoin({inner}, {outerKeySelector}, {innerKeySelector}, {resultSelector})")]
        public static extern EnumerableInstance<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector);

        /// <summary>
        /// Correlates the elements of two sequences based on key equality and groups
        /// the results. A specified System.Collections.Generic.IEqualityComparer&lt;T&gt;
        /// is used to compare keys.
        /// </summary>
        /// <param name="outer">
        /// The first sequence to join.
        /// </param>
        /// <param name="inner">
        /// The sequence to join to the first sequence.
        /// </param>
        /// <param name="outerKeySelector">
        /// A function to extract the join key from each element of the first sequence.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to extract the join key from each element of the second sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from an element from the first sequence
        /// and a collection of matching elements from the second sequence.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to hash and compare keys.
        /// </param>
        /// <typeparam name="TOuter">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TInner">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by the key selector functions.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains elements of type
        /// TResult that are obtained by performing a grouped join on two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// outer or inner or outerKeySelector or innerKeySelector or resultSelector
        /// is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({outer}).groupJoin({inner}, {outerKeySelector}, {innerKeySelector}, {resultSelector}, {comparer})")]
        public static extern EnumerableInstance<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Produces the set intersection of two sequences by using the default equality
        /// comparer to compare values.
        /// </summary>
        /// <param name="first">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements that
        /// also appear in second will be returned.
        /// </param>
        /// <param name="second">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements that
        /// also appear in the first sequence will be returned.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements that form the set intersection of two
        /// sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({first}).intersect({second})")]
        public static extern EnumerableInstance<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);

        /// <summary>
        /// Produces the set intersection of two sequences by using the specified System.Collections.Generic.IEqualityComparer&lt;T&gt;
        /// to compare values.
        /// </summary>
        /// <param name="first">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements that
        /// also appear in second will be returned.
        /// </param>
        /// <param name="second">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements that
        /// also appear in the first sequence will be returned.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements that form the set intersection of two
        /// sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({first}).intersect({second}, {comparer})")]
        public static extern EnumerableInstance<TSource> Intersect<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);

        /// <summary>
        /// Correlates the elements of two sequences based on matching keys. The default
        /// equality comparer is used to compare keys.
        /// </summary>
        /// <param name="outer">
        /// The first sequence to join.
        /// </param>
        /// <param name="inner">
        /// The sequence to join to the first sequence.
        /// </param>
        /// <param name="outerKeySelector">
        /// A function to extract the join key from each element of the first sequence.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to extract the join key from each element of the second sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from two matching elements.
        /// </param>
        /// <typeparam name="TOuter">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TInner">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by the key selector functions.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that has elements of type TResult
        /// that are obtained by performing an inner join on two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// outer or inner or outerKeySelector or innerKeySelector or resultSelector
        /// is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({this}).join({inner}, {outerKeySelector}, {innerKeySelector}, {resultSelector})")]
        public static extern EnumerableInstance<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector);

        /// <summary>
        /// Correlates the elements of two sequences based on matching keys. A specified
        /// System.Collections.Generic.IEqualityComparer&lt;T&gt; is used to compare keys.
        /// </summary>
        /// <param name="outer">
        /// The first sequence to join.
        /// </param>
        /// <param name="inner">
        /// The sequence to join to the first sequence.
        /// </param>
        /// <param name="outerKeySelector">
        /// A function to extract the join key from each element of the first sequence.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to extract the join key from each element of the second sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from two matching elements.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to hash and compare keys.
        /// </param>
        /// <typeparam name="TOuter">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TInner">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by the key selector functions.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that has elements of type TResult
        /// that are obtained by performing an inner join on two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// outer or inner or outerKeySelector or innerKeySelector or resultSelector
        /// is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({this}).join({inner}, {outerKeySelector}, {innerKeySelector}, {resultSelector}, {comparer})")]
        public static extern EnumerableInstance<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Returns an System.Int64 that represents the total number of elements in a
        /// sequence.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements to
        /// be counted.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The number of elements in the source sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The number of elements exceeds System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).count()")]
        public static extern long LongCount<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns an System.Int64 that represents how many elements in a sequence satisfy
        /// a condition.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements to
        /// be counted.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A number that represents how many elements in the sequence satisfy the condition
        /// in the predicate function.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The number of matching elements exceeds System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).count({predicate})")]
        public static extern long LongCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Returns the last element of a sequence.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return the last element of.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value at the last position in the source sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// The source sequence is empty.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).last()")]
        public static extern TSource Last<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return an element from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The last element in the sequence that passes the test in the specified predicate
        /// function.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// No element satisfies the condition in predicate.-or-The source sequence is
        /// empty.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).last({predicate})")]
        public static extern TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Returns the last element of a sequence, or a default value if the sequence
        /// contains no elements.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return the last element of.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// default(TSource) if the source sequence is empty; otherwise, the last element
        /// in the System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).lastOrDefault(null, {TSource:default})")]
        public static extern TSource LastOrDefault<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns the last element of a sequence that satisfies a condition or a default
        /// value if no such element is found.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return an element from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// default(TSource) if the sequence is empty or if no elements pass the test
        /// in the predicate function; otherwise, the last element that passes the test
        /// in the predicate function.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).lastOrDefault({predicate}, {TSource:default})")]
        public static extern TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Decimal values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Decimal&gt; in C# or Nullable(Of Decimal) in Visual
        /// Basic that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMax()")]
        public static extern decimal? Max(this EnumerableInstance<decimal?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Decimal values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Decimal&gt; in C# or Nullable(Of Decimal) in Visual
        /// Basic that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax()")]
        public static extern decimal? Max(this IEnumerable<decimal?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Decimal values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.max()")]
        public static extern decimal Max(this EnumerableInstance<decimal> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Decimal values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max()")]
        public static extern decimal Max(this IEnumerable<decimal> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Double values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Double&gt; in C# or Nullable(Of Double) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMax()")]
        public static extern double? Max(this EnumerableInstance<double?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Double values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Double&gt; in C# or Nullable(Of Double) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax()")]
        public static extern double? Max(this IEnumerable<double?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Double values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.max()")]
        public static extern double Max(this EnumerableInstance<double> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Double values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max()")]
        public static extern double Max(this IEnumerable<double> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Single values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Single&gt; in C# or Nullable(Of Single) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMax()")]
        public static extern float? Max(this EnumerableInstance<float?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Single values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Single&gt; in C# or Nullable(Of Single) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax()")]
        public static extern float? Max(this IEnumerable<float?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Single values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.max()")]
        public static extern float Max(this EnumerableInstance<float> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Single values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max()")]
        public static extern float Max(this IEnumerable<float> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int32 values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Int32&gt; in C# or Nullable(Of Int32) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMax()")]
        public static extern int? Max(this EnumerableInstance<int?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int32 values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Int327gt; in C# or Nullable(Of Int32) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax()")]
        public static extern int? Max(this IEnumerable<int?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int32 values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.max()")]
        public static extern int Max(this EnumerableInstance<int> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int32 values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max()")]
        public static extern int Max(this IEnumerable<int> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int64 values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Int64&gt; in C# or Nullable(Of Int64) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMax()")]
        public static extern long? Max(this EnumerableInstance<long?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of nullable System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int64 values to determine the maximum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Int64&gt; in C# or Nullable(Of Int64) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax()")]
        public static extern long? Max(this IEnumerable<long?> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int64 values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.max()")]
        public static extern long Max(this EnumerableInstance<long> source);

        /// <summary>
        /// Returns the maximum value in a sequence of System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int64 values to determine the maximum value of.
        /// </param>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max()")]
        public static extern long Max(this IEnumerable<long> source);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum nullable System.Decimal value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Decimal&gt; in C# or Nullable(Of Decimal) in Visual
        /// Basic that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax({selector})")]
        public static extern decimal? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum System.Decimal value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max({selector})")]
        public static extern decimal Max<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum nullable System.Double value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Double&gt; in C# or Nullable(Of Double) in Visual
        /// Basic that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax({selector})")]
        public static extern double? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum System.Double value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max({selector})")]
        public static extern double Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum nullable System.Single value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Single&gt; in C# or Nullable(Of Single) in Visual
        /// Basic that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax({selector})")]
        public static extern float? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum System.Single value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max({selector})")]
        public static extern float Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum nullable System.Int32 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Int32&gt; in C# or Nullable(Of Int32) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax({selector})")]
        public static extern int? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum System.Int32 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max({selector})")]
        public static extern int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum nullable System.Int64 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Int64&gt; in C# or Nullable(Of Int64) in Visual Basic
        /// that corresponds to the maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMax({selector})")]
        public static extern long? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum System.Int64 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max({selector})")]
        public static extern long Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Decimal values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Decimal&gt; in C# or Nullable(Of Decimal) in Visual
        /// Basic that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMin()")]
        public static extern decimal? Min(this EnumerableInstance<decimal?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Decimal values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Decimal&gt; in C# or Nullable(Of Decimal) in Visual
        /// Basic that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin()")]
        public static extern decimal? Min(this IEnumerable<decimal?> source);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum System.Int64 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max()")]
        public static extern TSource Max<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// maximum System.Int64 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the maximum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements in result.
        /// </typeparam>
        /// <returns>
        /// The maximum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).max({selector})")]
        public static extern TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);

        /// <summary>
        /// Returns the minimum TSource value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min()")]
        public static extern TSource Min<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum TResult value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements in result.
        /// </typeparam>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min({selector})")]
        public static extern TResult Min<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Decimal values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.min()")]
        public static extern decimal Min(this EnumerableInstance<decimal> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Decimal values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min()")]
        public static extern decimal Min(this IEnumerable<decimal> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Double values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Double&gt; in C# or Nullable(Of Double) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMin()")]
        public static extern double? Min(this EnumerableInstance<double?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Double values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Double&gt; in C# or Nullable(Of Double) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin()")]
        public static extern double? Min(this IEnumerable<double?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Double values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.min()")]
        public static extern double Min(this EnumerableInstance<double> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Double values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min()")]
        public static extern double Min(this IEnumerable<double> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Single values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Single&gt; in C# or Nullable(Of Single) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMin()")]
        public static extern float? Min(this EnumerableInstance<float?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Single values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Single&gt; in C# or Nullable(Of Single) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin()")]
        public static extern float? Min(this IEnumerable<float?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Single values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.min()")]
        public static extern float Min(this EnumerableInstance<float> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Single values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min()")]
        public static extern float Min(this IEnumerable<float> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int32 values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Int32&gt; in C# or Nullable(Of Int32) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMin()")]
        public static extern int? Min(this EnumerableInstance<int?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int32 values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Int32&gt; in C# or Nullable(Of Int32) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin()")]
        public static extern int? Min(this IEnumerable<int?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int32 values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.min()")]
        public static extern int Min(this EnumerableInstance<int> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int32 values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min()")]
        public static extern int Min(this IEnumerable<int> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int64 values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Int64&gt; in C# or Nullable(Of Int64) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableMin()")]
        public static extern long? Min(this EnumerableInstance<long?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of nullable System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int64 values to determine the minimum value
        /// of.
        /// </param>
        /// <returns>
        /// A value of type Nullable&lt;Int64&gt; in C# or Nullable(Of Int64) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin()")]
        public static extern long? Min(this IEnumerable<long?> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int64 values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("{this}.min()")]
        public static extern long Min(this EnumerableInstance<long> source);

        /// <summary>
        /// Returns the minimum value in a sequence of System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int64 values to determine the minimum value of.
        /// </param>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min()")]
        public static extern long Min(this IEnumerable<long> source);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum nullable System.Decimal value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Decimal&gt; in C# or Nullable(Of Decimal) in Visual
        /// Basic that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin({selector})")]
        public static extern decimal? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum System.Decimal value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min({selector})")]
        public static extern decimal Min<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum nullable System.Double value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Double&gt; in C# or Nullable(Of Double) in Visual
        /// Basic that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin({selector})")]
        public static extern double? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum System.Double value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min({selector})")]
        public static extern double Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum nullable System.Single value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Single&gt; in C# or Nullable(Of Single) in Visual
        /// Basic that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin({selector})")]
        public static extern float? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum System.Single value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min({selector})")]
        public static extern float Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum nullable System.Int32 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Int32&gt; in C# or Nullable(Of Int32) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin({selector})")]
        public static extern int? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum System.Int32 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min({selector})")]
        public static extern int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum nullable System.Int64 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The value of type Nullable&lt;Int64&gt; in C# or Nullable(Of Int64) in Visual Basic
        /// that corresponds to the minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableMin({selector})")]
        public static extern long? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector);

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the
        /// minimum System.Int64 value.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to determine the minimum value of.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The minimum value in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// source contains no elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).min({selector})")]
        public static extern long Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);

        /// <summary>
        /// Filters the elements of an System.Collections.IEnumerable based on a specified
        /// type.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.IEnumerable whose elements to filter.
        /// </param>
        /// <typeparam name="TResult">
        /// The type to filter the elements of the sequence on.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains elements from
        /// the input sequence of type TResult.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).ofType({TResult})")]
        public static extern EnumerableInstance<TResult> OfType<TResult>(this IEnumerable source);

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; whose elements are sorted according
        /// to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).orderBy({keySelector})")]
        public static extern OrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using a specified
        /// comparer.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; whose elements are sorted according
        /// to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).orderBy({keySelector}, {comparer})")]
        public static extern OrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer);

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; whose elements are sorted in
        /// descending order according to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).orderByDescending({keySelector})")]
        public static extern OrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector);

        /// <summary>
        /// Sorts the elements of a sequence in descending order by using a specified
        /// comparer.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; whose elements are sorted in
        /// descending order according to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).orderByDescending({keySelector}, {comparer})")]
        public static extern OrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IComparer<TKey> comparer);

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="start">
        /// The value of the first integer in the sequence.
        /// </param>
        /// <param name="count">
        /// The number of sequential integers to generate.
        /// </param>
        /// <returns>
        /// An IEnumerable&lt;Int32&gt; in C# or IEnumerable(Of Int32) in Visual Basic that
        /// contains a range of sequential integral numbers.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// count is less than 0.-or-start + count -1 is larger than System.Int32.MaxValue.
        /// </exception>
        public static extern EnumerableInstance<int> Range(int start, int count);

        /// <summary>
        /// Generates a sequence that contains one repeated value.
        /// </summary>
        /// <param name="element">
        /// The value to be repeated.
        /// </param>
        /// <param name="count">
        /// The number of times to repeat the value in the generated sequence.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the value to be repeated in the result sequence.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains a repeated value.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// count is less than 0.
        /// </exception>
        public static extern EnumerableInstance<TResult> Repeat<TResult>(TResult element, int count);

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to reverse.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence whose elements correspond to those of the input sequence in reverse
        /// order.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).reverse()")]
        public static extern EnumerableInstance<TSource> Reverse<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Projects each element of a sequence into a new form by incorporating the
        /// element's index.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to invoke a transform function on.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each source element; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the value returned by selector.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements are the result
        /// of invoking the transform function on each element of source.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).select({selector})")]
        public static extern EnumerableInstance<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector);

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to invoke a transform function on.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the value returned by selector.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements are the result
        /// of invoking the transform function on each element of source.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).select({selector})")]
        public static extern EnumerableInstance<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector);

        /// <summary>
        /// Projects each element of a sequence to an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// and flattens the resulting sequences into one sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to project.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the sequence returned by selector.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements are the result
        /// of invoking the one-to-many transform function on each element of the input
        /// sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).selectMany({selector})")]
        public static extern EnumerableInstance<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector);

        /// <summary>
        /// Projects each element of a sequence to an System.Collections.Generic.IEnumerable&lt;T&gt;,
        /// and flattens the resulting sequences into one sequence. The index of each
        /// source element is used in the projected form of that element.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to project.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each source element; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the sequence returned by selector.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements are the result
        /// of invoking the one-to-many transform function on each element of an input
        /// sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).selectMany({selector})")]
        public static extern EnumerableInstance<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> selector);

        /// <summary>
        /// Projects each element of a sequence to an System.Collections.Generic.IEnumerable&lt;T&gt;,
        /// flattens the resulting sequences into one sequence, and invokes a result
        /// selector function on each element therein.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to project.
        /// </param>
        /// <param name="collectionSelector">
        /// A transform function to apply to each element of the input sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A transform function to apply to each element of the intermediate sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TCollection">
        /// The type of the intermediate elements collected by collectionSelector.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the resulting sequence.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements are the result
        /// of invoking the one-to-many transform function collectionSelector on each
        /// element of source and then mapping each of those sequence elements and their
        /// corresponding source element to a result element.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or collectionSelector or resultSelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).selectMany({collectionSelector}, {resultSelector})")]
        public static extern EnumerableInstance<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);

        /// <summary>
        /// Projects each element of a sequence to an System.Collections.Generic.IEnumerable&lt;T&gt;,
        /// flattens the resulting sequences into one sequence, and invokes a result
        /// selector function on each element therein. The index of each source element
        /// is used in the intermediate projected form of that element.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to project.
        /// </param>
        /// <param name="collectionSelector">
        /// A transform function to apply to each source element; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <param name="resultSelector">
        /// A transform function to apply to each element of the intermediate sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TCollection">
        /// The type of the intermediate elements collected by collectionSelector.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the resulting sequence.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose elements are the result
        /// of invoking the one-to-many transform function collectionSelector on each
        /// element of source and then mapping each of those sequence elements and their
        /// corresponding source element to a result element.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or collectionSelector or resultSelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).selectMany({collectionSelector}, {resultSelector})")]
        public static extern EnumerableInstance<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);

        /// <summary>
        /// Determines whether two sequences are equal by comparing the elements by using
        /// the default equality comparer for their type.
        /// </summary>
        /// <param name="first">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to compare to second.
        /// </param>
        /// <param name="second">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to compare to the first sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// true if the two source sequences are of equal length and their corresponding
        /// elements are equal according to the default equality comparer for their type;
        /// otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({first}).sequenceEqual({second})")]
        public static extern bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);

        /// <summary>
        /// Determines whether two sequences are equal by comparing their elements by
        /// using a specified System.Collections.Generic.IEqualityComparer&lt;T&gt;.
        /// </summary>
        /// <param name="first">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to compare to second.
        /// </param>
        /// <param name="second">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to compare to the first sequence.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to use to compare elements.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// true if the two source sequences are of equal length and their corresponding
        /// elements compare equal according to comparer; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({first}).sequenceEqual({second}, {comparer})")]
        public static extern bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer);

        /// <summary>
        /// Returns the only element of a sequence, and throws an exception if there
        /// is not exactly one element in the sequence.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return the single element
        /// of.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The single element of the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// The input sequence contains more than one element.-or-The input sequence
        /// is empty.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).single()")]
        public static extern TSource Single<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition,
        /// and throws an exception if more than one such element exists.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return a single element from.
        /// </param>
        /// <param name="predicate">
        /// A function to test an element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The single element of the input sequence that satisfies a condition.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// No element satisfies the condition in predicate.-or-More than one element
        /// satisfies the condition in predicate.-or-The source sequence is empty.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).single({predicate})")]
        public static extern TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Returns the only element of a sequence, or a default value if the sequence
        /// is empty; this method throws an exception if there is more than one element
        /// in the sequence.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return the single element
        /// of.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The single element of the input sequence, or default(TSource) if the sequence
        /// contains no elements.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// The input sequence contains more than one element.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).singleOrDefault(null, {TSource:default})")]
        public static extern TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition
        /// or a default value if no such element exists; this method throws an exception
        /// if more than one element satisfies the condition.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return a single element from.
        /// </param>
        /// <param name="predicate">
        /// A function to test an element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The single element of the input sequence that satisfies the condition, or
        /// default(TSource) if no such element is found.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).singleOrDefault({predicate}, {TSource:default})")]
        public static extern TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the
        /// remaining elements.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return elements from.
        /// </param>
        /// <param name="count">
        /// The number of elements to skip before returning the remaining elements.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements that
        /// occur after the specified index in the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).skip({count})")]
        public static extern EnumerableInstance<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count);

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true
        /// and then returns the remaining elements.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return elements from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements from
        /// the input sequence starting at the first element in the linear series that
        /// does not pass the test specified by predicate.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).skipWhile({predicate})")]
        public static extern EnumerableInstance<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true
        /// and then returns the remaining elements. The element's index is used in the
        /// logic of the predicate function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to return elements from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements from
        /// the input sequence starting at the first element in the linear series that
        /// does not pass the test specified by predicate.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).skipWhile({predicate})")]
        public static extern EnumerableInstance<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Decimal values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Decimal.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableSum(System.Decimal.Zero)")]
        public static extern decimal? Sum(this EnumerableInstance<decimal?> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Decimal values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Decimal.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum(System.Decimal.Zero)")]
        public static extern decimal? Sum(this IEnumerable<decimal?> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Decimal values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Decimal.MaxValue.
        /// </exception>
        [Bridge.Template("{this}.sum(System.Decimal.Zero)")]
        public static extern decimal Sum(this EnumerableInstance<decimal> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Decimal values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Decimal values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Decimal.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum(System.Decimal.Zero)")]
        public static extern decimal Sum(this IEnumerable<decimal> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Double values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableSum()")]
        public static extern double? Sum(this EnumerableInstance<double?> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Double values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum()")]
        public static extern double? Sum(this IEnumerable<double?> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Double values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("{this}.sum()")]
        public static extern double Sum(this EnumerableInstance<double> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Double values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Double values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum()")]
        public static extern double Sum(this IEnumerable<double> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Single values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableSum()")]
        public static extern float? Sum(this EnumerableInstance<float?> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Single values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum()")]
        public static extern float? Sum(this IEnumerable<float?> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Single values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("{this}.sum()")]
        public static extern float Sum(this EnumerableInstance<float> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Single values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Single values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum()")]
        public static extern float Sum(this IEnumerable<float> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int32 values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int32.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableSum()")]
        public static extern int? Sum(this EnumerableInstance<int?> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int32 values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int32.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum()")]
        public static extern int? Sum(this IEnumerable<int?> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int32 values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int32.MaxValue.
        /// </exception>
        [Bridge.Template("{this}.sum()")]
        public static extern int Sum(this EnumerableInstance<int> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int32 values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int32.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum()")]
        public static extern int Sum(this IEnumerable<int> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int64 values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("{this}.nullableSum(System.Int64.Zero)")]
        public static extern long? Sum(this EnumerableInstance<long?> source);

        /// <summary>
        /// Computes the sum of a sequence of nullable System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of nullable System.Int64 values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum(System.Int64.Zero)")]
        public static extern long? Sum(this IEnumerable<long?> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int64 values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int64.MaxValue.
        /// </exception>
        [Bridge.Template("{this}.sum(System.Int64.Zero)")]
        public static extern long Sum(this EnumerableInstance<long> source);

        /// <summary>
        /// Computes the sum of a sequence of System.Int64 values.
        /// </summary>
        /// <param name="source">
        /// A sequence of System.Int64 values to calculate the sum of.
        /// </param>
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int64.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum(System.Int64.Zero)")]
        public static extern long Sum(this IEnumerable<long> source);

        /// <summary>
        /// Computes the sum of the sequence of nullable System.Decimal values that are
        /// obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Decimal.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum({selector}, System.Decimal.Zero)")]
        public static extern decimal? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector);

        /// <summary>
        /// Computes the sum of the sequence of System.Decimal values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Decimal.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum({selector}, System.Decimal.Zero)")]
        public static extern decimal Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);

        /// <summary>
        /// Computes the sum of the sequence of nullable System.Double values that are
        /// obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum({selector})")]
        public static extern double? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector);

        /// <summary>
        /// Computes the sum of the sequence of System.Double values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum({selector})")]
        public static extern double Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);

        /// <summary>
        /// Computes the sum of the sequence of nullable System.Single values that are
        /// obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum({selector})")]
        public static extern float? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector);

        /// <summary>
        /// Computes the sum of the sequence of System.Single values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum({selector})")]
        public static extern float Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);

        /// <summary>
        /// Computes the sum of the sequence of nullable System.Int32 values that are
        /// obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int32.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum({selector})")]
        public static extern int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector);

        /// <summary>
        /// Computes the sum of the sequence of System.Int32 values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int32.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum({selector})")]
        public static extern int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);

        /// <summary>
        /// Computes the sum of the sequence of nullable System.Int64 values that are
        /// obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int64.MaxValue.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).nullableSum({selector}, System.Int64.Zero)")]
        public static extern long? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector);

        /// <summary>
        /// Computes the sum of the sequence of System.Int64 values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values that are used to calculate a sum.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is null.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The sum is larger than System.Int64.MaxValue.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).sum({selector}, System.Int64.Zero)")]
        public static extern long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>
        /// <param name="source">
        /// The sequence to return elements from.
        /// </param>
        /// <param name="count">
        /// The number of elements to return.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the specified
        /// number of elements from the start of the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).take({count})")]
        public static extern EnumerableInstance<TSource> Take<TSource>(this IEnumerable<TSource> source, int count);

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>
        /// <param name="source">
        /// A sequence to return elements from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements from
        /// the input sequence that occur before the element at which the test no longer
        /// passes.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).takeWhile({predicate})")]
        public static extern EnumerableInstance<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="source">
        /// The sequence to return elements from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains elements from
        /// the input sequence that occur before the element at which the test no longer
        /// passes.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).takeWhile({predicate})")]
        public static extern EnumerableInstance<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);

        /// <summary>
        /// Performs a subsequent ordering of the elements in a sequence in ascending
        /// order according to a key.
        /// </summary>
        /// <param name="source">
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; that contains elements to sort.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; whose elements are sorted according
        /// to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).thenBy({keySelector})")]
        public static extern IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);

        /// <summary>
        /// Performs a subsequent ordering of the elements in a sequence in ascending
        /// order by using a specified comparer.
        /// </summary>
        /// <param name="source">
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; that contains elements to sort.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; whose elements are sorted according
        /// to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).thenBy({keySelector}, {comparer})")]
        public static extern IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);

        /// <summary>
        /// Performs a subsequent ordering of the elements in a sequence in descending
        /// order, according to a key.
        /// </summary>
        /// <param name="source">
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; that contains elements to sort.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; whose elements are sorted in
        /// descending order according to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).thenByDescending({keySelector}, {comparer})")]
        public static extern IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);

        /// <summary>
        /// Performs a subsequent ordering of the elements in a sequence in descending
        /// order by using a specified comparer.
        /// </summary>
        /// <param name="source">
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; that contains elements to sort.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// An System.Linq.IOrderedEnumerable&lt;TElement&gt; whose elements are sorted in
        /// descending order according to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        /// <remarks>Bridge.NET has no mapping for this in JavaScript.</remarks>
        [Bridge.Template("System.Linq.Enumerable.from({source}).thenByDescending({keySelector}, {comparer})")]
        public static extern IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);

        /// <summary>
        /// Creates an array from a System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to create an array from.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An array that contains the elements from the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).ToArray()")]
        public static extern TSource[] ToArray<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Creates a System.Collections.Generic.Dictionary&lt;TKey,TValue&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// according to a specified key selector function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Collections.Generic.Dictionary&lt;TKey,TValue&gt;
        /// from.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A System.Collections.Generic.Dictionary&lt;TKey,TValue&gt; that contains keys and
        /// values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.-or-keySelector produces a key that is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// keySelector produces duplicate keys for two elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toDictionary({keySelector}, null, {TKey}, {TSource})")]
        public static extern Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector);

        /// <summary>
        /// Creates a System.Collections.Generic.Dictionary&lt;TKey,TValue&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// according to specified key selector and element selector functions.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Collections.Generic.Dictionary&lt;TKey,TValue&gt;
        /// from.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <param name="elementSelector">
        /// A transform function to produce a result element value from each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the value returned by elementSelector.
        /// </typeparam>
        /// <returns>
        /// A System.Collections.Generic.Dictionary&lt;TKey,TValue&gt; that contains values
        /// of type TElement selected from the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector is null.-or-keySelector produces
        /// a key that is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// keySelector produces duplicate keys for two elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toDictionary({keySelector}, {elementSelector}, {TKey}, {TElement})")]
        public static extern Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);

        /// <summary>
        /// Creates a System.Collections.Generic.Dictionary&lt;TKey,TValue&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// according to a specified key selector function and key comparer.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Collections.Generic.Dictionary&lt;TKey,TValue&gt;
        /// from.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A System.Collections.Generic.Dictionary&lt;TKey,TValue&gt; that contains keys and
        /// values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.-or-keySelector produces a key that is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// keySelector produces duplicate keys for two elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toDictionary({keySelector}, null, {TKey}, {TSource}, {comparer})")]
        public static extern Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Creates a System.Collections.Generic.Dictionary&lt;TKey,TValue&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// according to a specified key selector function, a comparer, and an element
        /// selector function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Collections.Generic.Dictionary&lt;TKey,TValue&gt;
        /// from.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <param name="elementSelector">
        /// A transform function to produce a result element value from each element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the value returned by elementSelector.
        /// </typeparam>
        /// <returns>
        /// A System.Collections.Generic.Dictionary&lt;TKey,TValue&gt; that contains values
        /// of type TElement selected from the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector is null.-or-keySelector produces
        /// a key that is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// keySelector produces duplicate keys for two elements.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toDictionary({keySelector}, {elementSelector}, {TKey}, {TElement}, {comparer})")]
        public static extern Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Creates a System.Collections.Generic.List&lt;T&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Collections.Generic.List&lt;T&gt;
        /// from.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A System.Collections.Generic.List&lt;T&gt; that contains elements from the input
        /// sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toList({TSource})")]
        public static extern List<TSource> ToList<TSource>(this IEnumerable<TSource> source);

        /// <summary>
        /// Creates a System.Linq.Lookup&lt;TKey,TElement&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// according to a specified key selector function.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Linq.Lookup&lt;TKey,TElement&gt;
        /// from.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A System.Linq.Lookup&lt;TKey,TElement&gt; that contains keys and values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toLookup({keySelector})")]
        public static extern Lookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector);

        /// <summary>
        /// Creates a System.Linq.Lookup&lt;TKey,TElement&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// according to specified key selector and element selector functions.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Linq.Lookup&lt;TKey,TElement&gt;
        /// from.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <param name="elementSelector">
        /// A transform function to produce a result element value from each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the value returned by elementSelector.
        /// </typeparam>
        /// <returns>
        /// A System.Linq.Lookup&lt;TKey,TElement&gt; that contains values of type TElement
        /// selected from the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toLookup({keySelector}, {elementSelector})")]
        public static extern Lookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);

        /// <summary>
        /// Creates a System.Linq.Lookup&lt;TKey,TElement&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// according to a specified key selector function and key comparer.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Linq.Lookup&lt;TKey,TElement&gt;
        /// from.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A System.Linq.Lookup&lt;TKey,TElement&gt; that contains keys and values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toLookup({keySelector}, null, {comparer})")]
        public static extern Lookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Creates a System.Linq.Lookup&lt;TKey,TElement&gt; from an System.Collections.Generic.IEnumerable&lt;T&gt;
        /// according to a specified key selector function, a comparer and an element
        /// selector function.
        /// </summary>
        /// <param name="source">
        /// The System.Collections.Generic.IEnumerable&lt;T&gt; to create a System.Linq.Lookup&lt;TKey,TElement&gt;
        /// from.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from each element.
        /// </param>
        /// <param name="elementSelector">
        /// A transform function to produce a result element value from each element.
        /// </param>
        /// <param name="comparer">
        /// An System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the value returned by elementSelector.
        /// </typeparam>
        /// <returns>
        /// A System.Linq.Lookup&lt;TKey,TElement&gt; that contains values of type TElement
        /// selected from the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).toLookup({keySelector}, {elementSelector}, {comparer})")]
        public static extern Lookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);

        /// <summary>
        /// Produces the set union of two sequences by using the default equality comparer.
        /// </summary>
        /// <param name="first">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements form
        /// the first set for the union.
        /// </param>
        /// <param name="second">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements form
        /// the second set for the union.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements from
        /// both input sequences, excluding duplicates.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({first}).union({second})")]
        public static extern EnumerableInstance<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);

        /// <summary>
        /// Produces the set union of two sequences by using a specified System.Collections.Generic.IEqualityComparer&lt;T&gt;.
        /// </summary>
        /// <param name="first">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements form
        /// the first set for the union.
        /// </param>
        /// <param name="second">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements form
        /// the second set for the union.
        /// </param>
        /// <param name="comparer">
        /// The System.Collections.Generic.IEqualityComparer&lt;T&gt; to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements from
        /// both input sequences, excluding duplicates.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({first}).union({second}, {comparer})")]
        public static extern EnumerableInstance<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer);

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to filter.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains elements from
        /// the input sequence that satisfy the condition.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).where({predicate})")]
        public static extern EnumerableInstance<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is
        /// used in the logic of the predicate function.
        /// </summary>
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; to filter.
        /// </param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains elements from
        /// the input sequence that satisfy the condition.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({source}).where({predicate})")]
        public static extern EnumerableInstance<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);

        /// <summary>
        /// Merges two sequences by using the specified predicate function.
        /// </summary>
        /// <param name="first">
        /// The first sequence to merge.
        /// </param>
        /// <param name="second">
        /// The second sequence to merge.
        /// </param>
        /// <param name="resultSelector">
        /// A function that specifies how to merge the elements from the two sequences.
        /// </param>
        /// <typeparam name="TFirst">
        /// The type of the elements of the first input sequence.
        /// </typeparam>
        /// <typeparam name="TSecond">
        /// The type of the elements of the second input sequence.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the result sequence.
        /// </typeparam>
        /// <returns>
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; that contains merged elements
        /// of two input sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is null.
        /// </exception>
        [Bridge.Template("System.Linq.Enumerable.from({first}).zip({second}, {resultSelector})")]
        public static extern EnumerableInstance<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector);
    }
}