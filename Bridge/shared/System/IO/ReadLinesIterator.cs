using System.Collections;
/*
 * https://github.com/Microsoft/referencesource/blob/master/mscorlib/system/io/ReadLinesIterator.cs
 */

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace System.IO
{
    abstract internal class Iterator<TSource> : IEnumerable<TSource>, IEnumerator<TSource>
    {
        internal int state;
        internal TSource current;

        public Iterator()
        {
        }

        public TSource Current
        {
            get
            {
                return current;
            }
        }

        protected abstract Iterator<TSource> Clone();

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            current = default(TSource);
            state = -1;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            if (state == 0)
            {
                state = 1;
                return this;
            }

            Iterator<TSource> duplicate = Clone();
            duplicate.state = 1;
            return duplicate;
        }

        public abstract bool MoveNext();

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void IEnumerator.Reset()
        {
            throw new NotSupportedException();
        }

    }

    // An iterator that returns a single line at-a-time from a given file.
    //
    // Known issues which cannot be changed to remain compatible with 4.0:
    //
    //  - The underlying StreamReader is allocated upfront for the IEnumerable<T> before
    //    GetEnumerator has even been called. While this is good in that exceptions such as
    //    DirectoryNotFoundException and FileNotFoundException are thrown directly by
    //    File.ReadLines (which the user probably expects), it also means that the reader
    //    will be leaked if the user never actually foreach's over the enumerable (and hence
    //    calls Dispose on at least one IEnumerator<T> instance).
    //
    //  - Reading to the end of the IEnumerator<T> disposes it. This means that Dispose
    //    is called twice in a normal foreach construct.
    //
    //  - IEnumerator<T> instances from the same IEnumerable<T> party on the same underlying
    //    reader (Dev10 Bugs 904764).
    //
    internal class ReadLinesIterator : Iterator<string>
    {
        private readonly string _path;
        private readonly Encoding _encoding;
        private StreamReader _reader;

        private ReadLinesIterator(string path, Encoding encoding, StreamReader reader)
        {
            Contract.Requires(path != null);
            Contract.Requires(path.Length > 0);
            Contract.Requires(encoding != null);
            Contract.Requires(reader != null);

            _path = path;
            _encoding = encoding;
            _reader = reader;
        }

        public override bool MoveNext()
        {
            if (this._reader != null)
            {
                this.current = _reader.ReadLine();
                if (this.current != null)
                    return true;

                // To maintain 4.0 behavior we Dispose
                // after reading to the end of the reader.
                Dispose();
            }

            return false;
        }
        
        protected override Iterator<string> Clone()
        {
            // NOTE: To maintain the same behavior with the previous yield-based
            // iterator in 4.0, we have all the IEnumerator<T> instances share the same
            // underlying reader. If we have already been disposed, _reader will be null,
            // which will cause CreateIterator to simply new up a new instance to start up
            // a new iteration. Dev10 Bugs 904764 has been filed to fix this in next side-
            // by-side release.
            return CreateIterator(_path, _encoding, _reader);
        }
        
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (_reader != null)
                    {
                        _reader.Dispose();
                    }
                }
            }
            finally
            {
                _reader = null;
                base.Dispose(disposing);
            }
        }

        internal static ReadLinesIterator CreateIterator(string path, Encoding encoding)
        {
            return CreateIterator(path, encoding, (StreamReader)null);
        }

        private static ReadLinesIterator CreateIterator(string path, Encoding encoding, StreamReader reader)
        {
            return new ReadLinesIterator(path, encoding, reader ?? new StreamReader(path, encoding));
        }
    }
}
