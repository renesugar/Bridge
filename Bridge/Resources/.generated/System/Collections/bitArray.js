    Bridge.define("System.Collections.BitArray", {
        inherits: [System.Collections.ICollection,System.ICloneable],
        statics: {
            fields: {
                BitsPerInt32: 0,
                BytesPerInt32: 0,
                BitsPerByte: 0,
                _ShrinkThreshold: 0
            },
            ctors: {
                init: function () {
                    this.BitsPerInt32 = 32;
                    this.BytesPerInt32 = 4;
                    this.BitsPerByte = 8;
                    this._ShrinkThreshold = 256;
                }
            },
            methods: {
                GetArrayLength: function (n, div) {
                    return n > 0 ? ((((((Bridge.Int.div((((n - 1) | 0)), div)) | 0)) + 1) | 0)) : 0;
                }
            }
        },
        fields: {
            m_array: null,
            m_length: 0,
            _version: 0
        },
        props: {
            Length: {
                get: function () {
                    return this.m_length;
                },
                set: function (value) {
                    if (value < 0) {
                        throw new System.ArgumentOutOfRangeException.$ctor4("value", "Non-negative number required.");
                    }

                    var newints = System.Collections.BitArray.GetArrayLength(value, System.Collections.BitArray.BitsPerInt32);
                    if (newints > this.m_array.length || ((newints + System.Collections.BitArray._ShrinkThreshold) | 0) < this.m_array.length) {
                        var newarray = System.Array.init(newints, 0, System.Int32);
                        System.Array.copy(this.m_array, 0, newarray, 0, newints > this.m_array.length ? this.m_array.length : newints);
                        this.m_array = newarray;
                    }

                    if (value > this.m_length) {
                        var last = (System.Collections.BitArray.GetArrayLength(this.m_length, System.Collections.BitArray.BitsPerInt32) - 1) | 0;
                        var bits = this.m_length % 32;
                        if (bits > 0) {
                            this.m_array[System.Array.index(last, this.m_array)] = this.m_array[System.Array.index(last, this.m_array)] & ((((1 << bits) - 1) | 0));
                        }

                        System.Array.fill(this.m_array, 0, ((last + 1) | 0), ((((newints - last) | 0) - 1) | 0));
                    }

                    this.m_length = value;
                    this._version = (this._version + 1) | 0;
                }
            },
            Count: {
                get: function () {
                    return this.m_length;
                }
            },
            System$Collections$ICollection$IsSynchronized: {
                get: function () {
                    return false;
                }
            },
            System$Collections$ICollection$SyncRoot: {
                get: function () {
                    return this;
                }
            },
            IsReadOnly: {
                get: function () {
                    return false;
                }
            }
        },
        alias: [
            "copyTo", "System$Collections$ICollection$copyTo",
            "Count", "System$Collections$ICollection$Count",
            "clone", "System$ICloneable$clone",
            "GetEnumerator", "System$Collections$IEnumerable$GetEnumerator"
        ],
        ctors: {
            $ctor3: function (length) {
                System.Collections.BitArray.$ctor4.call(this, length, false);
            },
            $ctor4: function (length, defaultValue) {
                this.$initialize();
                if (length < 0) {
                    throw new System.ArgumentOutOfRangeException.$ctor4("length", "Index is less than zero.");
                }

                this.m_array = System.Array.init(System.Collections.BitArray.GetArrayLength(length, System.Collections.BitArray.BitsPerInt32), 0, System.Int32);
                this.m_length = length;

                var fillValue = defaultValue ? (-1) : 0;
                for (var i = 0; i < this.m_array.length; i = (i + 1) | 0) {
                    this.m_array[System.Array.index(i, this.m_array)] = fillValue;
                }

                this._version = 0;
            },
            $ctor1: function (bytes) {
                this.$initialize();
                if (bytes == null) {
                    throw new System.ArgumentNullException.$ctor1("bytes");
                }
                if (bytes.length > 268435455) {
                    throw new System.ArgumentException.$ctor3(System.String.format("The input array length must not exceed Int32.MaxValue / {0}. Otherwise BitArray.Length would exceed Int32.MaxValue.", [Bridge.box(System.Collections.BitArray.BitsPerByte, System.Int32)]), "bytes");
                }

                this.m_array = System.Array.init(System.Collections.BitArray.GetArrayLength(bytes.length, System.Collections.BitArray.BytesPerInt32), 0, System.Int32);
                this.m_length = Bridge.Int.mul(bytes.length, System.Collections.BitArray.BitsPerByte);

                var i = 0;
                var j = 0;
                while (((bytes.length - j) | 0) >= 4) {
                    this.m_array[System.Array.index(Bridge.identity(i, (i = (i + 1) | 0)), this.m_array)] = (bytes[System.Array.index(j, bytes)] & 255) | ((bytes[System.Array.index(((j + 1) | 0), bytes)] & 255) << 8) | ((bytes[System.Array.index(((j + 2) | 0), bytes)] & 255) << 16) | ((bytes[System.Array.index(((j + 3) | 0), bytes)] & 255) << 24);
                    j = (j + 4) | 0;
                }

                var r = (bytes.length - j) | 0;
                if (r === 3) {
                    this.m_array[System.Array.index(i, this.m_array)] = ((bytes[System.Array.index(((j + 2) | 0), bytes)] & 255) << 16);
                    r = 2;
                }

                if (r === 2) {
                    this.m_array[System.Array.index(i, this.m_array)] = this.m_array[System.Array.index(i, this.m_array)] | ((bytes[System.Array.index(((j + 1) | 0), bytes)] & 255) << 8);
                    r = 1;
                }

                if (r === 1) {
                    this.m_array[System.Array.index(i, this.m_array)] = this.m_array[System.Array.index(i, this.m_array)] | (bytes[System.Array.index(j, bytes)] & 255);
                }

                this._version = 0;
            },
            ctor: function (values) {
                var $t;
                this.$initialize();
                if (values == null) {
                    throw new System.ArgumentNullException.$ctor1("values");
                }

                this.m_array = System.Array.init(System.Collections.BitArray.GetArrayLength(values.length, System.Collections.BitArray.BitsPerInt32), 0, System.Int32);
                this.m_length = values.length;

                for (var i = 0; i < values.length; i = (i + 1) | 0) {
                    if (values[System.Array.index(i, values)]) {
                        this.m_array[System.Array.index(($t = ((Bridge.Int.div(i, 32)) | 0)), this.m_array)] = this.m_array[System.Array.index($t, this.m_array)] | (1 << (i % 32));
                    }
                }

                this._version = 0;
            },
            $ctor5: function (values) {
                this.$initialize();
                if (values == null) {
                    throw new System.ArgumentNullException.$ctor1("values");
                }
                if (values.length > 67108863) {
                    throw new System.ArgumentException.$ctor3(System.String.format("The input array length must not exceed Int32.MaxValue / {0}. Otherwise BitArray.Length would exceed Int32.MaxValue.", [Bridge.box(System.Collections.BitArray.BitsPerInt32, System.Int32)]), "values");
                }

                this.m_array = System.Array.init(values.length, 0, System.Int32);
                this.m_length = Bridge.Int.mul(values.length, System.Collections.BitArray.BitsPerInt32);

                System.Array.copy(values, 0, this.m_array, 0, values.length);

                this._version = 0;
            },
            $ctor2: function (bits) {
                this.$initialize();
                if (bits == null) {
                    throw new System.ArgumentNullException.$ctor1("bits");
                }

                var arrayLength = System.Collections.BitArray.GetArrayLength(bits.m_length, System.Collections.BitArray.BitsPerInt32);
                this.m_array = System.Array.init(arrayLength, 0, System.Int32);
                this.m_length = bits.m_length;

                System.Array.copy(bits.m_array, 0, this.m_array, 0, arrayLength);

                this._version = bits._version;
            }
        },
        methods: {
            getItem: function (index) {
                return this.Get(index);
            },
            setItem: function (index, value) {
                this.Set(index, value);
            },
            copyTo: function (array, index) {
                if (array == null) {
                    throw new System.ArgumentNullException.$ctor1("array");
                }

                if (index < 0) {
                    throw new System.ArgumentOutOfRangeException.$ctor1("index");
                }

                if (System.Array.getRank(array) !== 1) {
                    throw new System.ArgumentException.$ctor1("Only single dimensional arrays are supported for the requested action.");
                }

                if (Bridge.is(array, System.Array.type(System.Int32))) {
                    System.Array.copy(this.m_array, 0, array, index, System.Collections.BitArray.GetArrayLength(this.m_length, System.Collections.BitArray.BitsPerInt32));
                } else if (Bridge.is(array, System.Array.type(System.Byte))) {
                    var arrayLength = System.Collections.BitArray.GetArrayLength(this.m_length, System.Collections.BitArray.BitsPerByte);
                    if ((((array.length - index) | 0)) < arrayLength) {
                        throw new System.ArgumentException.$ctor1("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
                    }

                    var b = Bridge.cast(array, System.Array.type(System.Byte));
                    for (var i = 0; i < arrayLength; i = (i + 1) | 0) {
                        b[System.Array.index(((index + i) | 0), b)] = ((this.m_array[System.Array.index(((Bridge.Int.div(i, 4)) | 0), this.m_array)] >> (Bridge.Int.mul((i % 4), 8))) & 255) & 255;
                    }
                } else if (Bridge.is(array, System.Array.type(System.Boolean))) {
                    if (((array.length - index) | 0) < this.m_length) {
                        throw new System.ArgumentException.$ctor1("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
                    }

                    var b1 = Bridge.cast(array, System.Array.type(System.Boolean));
                    for (var i1 = 0; i1 < this.m_length; i1 = (i1 + 1) | 0) {
                        b1[System.Array.index(((index + i1) | 0), b1)] = ((this.m_array[System.Array.index(((Bridge.Int.div(i1, 32)) | 0), this.m_array)] >> (i1 % 32)) & 1) !== 0;
                    }
                } else {
                    throw new System.ArgumentException.$ctor1("Only supported array types for CopyTo on BitArrays are Boolean[], Int32[] and Byte[].");
                }
            },
            Get: function (index) {
                if (index < 0 || index >= this.Length) {
                    throw new System.ArgumentOutOfRangeException.$ctor4("index", "Index was out of range. Must be non-negative and less than the size of the collection.");
                }

                return (this.m_array[System.Array.index(((Bridge.Int.div(index, 32)) | 0), this.m_array)] & (1 << (index % 32))) !== 0;
            },
            Set: function (index, value) {
                var $t, $t1;
                if (index < 0 || index >= this.Length) {
                    throw new System.ArgumentOutOfRangeException.$ctor4("index", "Index was out of range. Must be non-negative and less than the size of the collection.");
                }

                if (value) {
                    this.m_array[System.Array.index(($t = ((Bridge.Int.div(index, 32)) | 0)), this.m_array)] = this.m_array[System.Array.index($t, this.m_array)] | (1 << (index % 32));
                } else {
                    this.m_array[System.Array.index(($t1 = ((Bridge.Int.div(index, 32)) | 0)), this.m_array)] = this.m_array[System.Array.index($t1, this.m_array)] & (~(1 << (index % 32)));
                }

                this._version = (this._version + 1) | 0;
            },
            SetAll: function (value) {
                var fillValue = value ? (-1) : 0;
                var ints = System.Collections.BitArray.GetArrayLength(this.m_length, System.Collections.BitArray.BitsPerInt32);
                for (var i = 0; i < ints; i = (i + 1) | 0) {
                    this.m_array[System.Array.index(i, this.m_array)] = fillValue;
                }

                this._version = (this._version + 1) | 0;
            },
            And: function (value) {
                if (value == null) {
                    throw new System.ArgumentNullException.$ctor1("value");
                }
                if (this.Length !== value.Length) {
                    throw new System.ArgumentException.$ctor1("Array lengths must be the same.");
                }

                var ints = System.Collections.BitArray.GetArrayLength(this.m_length, System.Collections.BitArray.BitsPerInt32);
                for (var i = 0; i < ints; i = (i + 1) | 0) {
                    this.m_array[System.Array.index(i, this.m_array)] = this.m_array[System.Array.index(i, this.m_array)] & value.m_array[System.Array.index(i, value.m_array)];
                }

                this._version = (this._version + 1) | 0;
                return this;
            },
            Or: function (value) {
                if (value == null) {
                    throw new System.ArgumentNullException.$ctor1("value");
                }
                if (this.Length !== value.Length) {
                    throw new System.ArgumentException.$ctor1("Array lengths must be the same.");
                }

                var ints = System.Collections.BitArray.GetArrayLength(this.m_length, System.Collections.BitArray.BitsPerInt32);
                for (var i = 0; i < ints; i = (i + 1) | 0) {
                    this.m_array[System.Array.index(i, this.m_array)] = this.m_array[System.Array.index(i, this.m_array)] | value.m_array[System.Array.index(i, value.m_array)];
                }

                this._version = (this._version + 1) | 0;
                return this;
            },
            Xor: function (value) {
                if (value == null) {
                    throw new System.ArgumentNullException.$ctor1("value");
                }
                if (this.Length !== value.Length) {
                    throw new System.ArgumentException.$ctor1("Array lengths must be the same.");
                }

                var ints = System.Collections.BitArray.GetArrayLength(this.m_length, System.Collections.BitArray.BitsPerInt32);
                for (var i = 0; i < ints; i = (i + 1) | 0) {
                    this.m_array[System.Array.index(i, this.m_array)] = this.m_array[System.Array.index(i, this.m_array)] ^ value.m_array[System.Array.index(i, value.m_array)];
                }

                this._version = (this._version + 1) | 0;
                return this;
            },
            Not: function () {
                var ints = System.Collections.BitArray.GetArrayLength(this.m_length, System.Collections.BitArray.BitsPerInt32);
                for (var i = 0; i < ints; i = (i + 1) | 0) {
                    this.m_array[System.Array.index(i, this.m_array)] = ~this.m_array[System.Array.index(i, this.m_array)];
                }

                this._version = (this._version + 1) | 0;
                return this;
            },
            clone: function () {
                var bitArray = new System.Collections.BitArray.$ctor5(this.m_array);
                bitArray._version = this._version;
                bitArray.m_length = this.m_length;
                return bitArray;
            },
            GetEnumerator: function () {
                return new System.Collections.BitArray.BitArrayEnumeratorSimple(this);
            }
        }
    });
