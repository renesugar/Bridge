﻿/// <reference path="..\..\Runner\resources\qunit\qunit.d.ts" />
/// <reference path="..\..\Runner\TypeScript\App1\bridge.d.ts" />
/// <reference path="..\..\Runner\TypeScript\App1\BasicTypes.d.ts" />

"use strict";

QUnit.module("TypeScript - Basic Types");
QUnit.test("Fields of basic types", function (assert) {
    var instance: BasicTypes.BasicTypes = new BasicTypes.BasicTypes();

    assert.deepEqual(instance.BoolValue, true, "boolValue");
    assert.deepEqual(instance.IntegerValue, -1000, "integerValue");
    assert.deepEqual(instance.FloatValue, 2.3, "floatValue");
    assert.deepEqual(instance.StringValue, "Some string value", "stringValue");
    assert.deepEqual(instance.IntegerArray, [1, 2, 3], "integerArray");
    assert.deepEqual(instance.StringArray, ["1", "2", "3"], "stringArray");
    assert.deepEqual(instance.ColorArray, [BasicTypes.Color.Blue, BasicTypes.Color.Green, BasicTypes.Color.Red], "colorArray");
    assert.deepEqual(instance.ColorValue, BasicTypes.Color.Green, "colorValue");
    assert.deepEqual(instance.AnyValueString, "AnyValueString", "anyValueString");
    assert.deepEqual(Bridge.unbox(instance.AnyValueInteger), 1, "anyValueInteger");
    assert.deepEqual(instance.DynamicValueInteger, 7, "dynamicValueInteger");
    assert.deepEqual(instance.VoidFunction(), instance.UndefinedValue, "Void and undefined values");
});

QUnit.test("Issue #430", function (assert) {
    var instance: BasicTypes.BasicTypes = new BasicTypes.BasicTypes();

    assert.deepEqual(instance.TwoDimensionalArray[0][0], 1, "Getting twoDimensionalArray[0][0] = 1");
    assert.deepEqual(instance.TwoDimensionalArray[0][1], 2, "Getting twoDimensionalArray[0][1] = 2");
    assert.deepEqual(instance.TwoDimensionalArray[0][2], 3, "Getting twoDimensionalArray[0][2] = 3");
    assert.deepEqual(instance.TwoDimensionalArray[1][0], 5, "Getting twoDimensionalArray[1][0] = 5");
    assert.deepEqual(instance.TwoDimensionalArray[1][1], 8, "Getting twoDimensionalArray[1][1] = 8");

    instance.TwoDimensionalArray[0][0] = 10;
    assert.deepEqual(instance.TwoDimensionalArray[0][0], 10, "Setting twoDimensionalArray[0][0] = 10");

    instance.TwoDimensionalArray[0][1] = 20;
    assert.deepEqual(instance.TwoDimensionalArray[0][1], 20, "Setting twoDimensionalArray[0][1] = 20");

    instance.TwoDimensionalArray[0][2] = 30;
    assert.deepEqual(instance.TwoDimensionalArray[0][2], 30, "Setting twoDimensionalArray[0][2] = 30");

    instance.TwoDimensionalArray[1][0] = 50;
    assert.deepEqual(instance.TwoDimensionalArray[1][0], 50, "Setting twoDimensionalArray[1][0] = 50");

    instance.TwoDimensionalArray[1][1] = 80;
    assert.deepEqual(instance.TwoDimensionalArray[1][1], 80, "Setting twoDimensionalArray[1][1] = 80");
});

QUnit.test("Reserved words", function (assert) {
    var k = new BasicTypes.Keywords();

    assert.deepEqual(k.Break, "break", "break");
    assert.deepEqual(k.Case, "case", "case");
    assert.deepEqual(k.Catch, "catch", "catch");
    assert.deepEqual(k.Class, "class", "class");
    assert.deepEqual(k.Const, "const", "const");
    assert.deepEqual(k.Continue, "continue", "continue");
    assert.deepEqual(k.Debugger, "debugger", "debugger");
    assert.deepEqual(k.Default, "default", "default");
    assert.deepEqual(k.Delete, "delete", "delete");
    assert.deepEqual(k.Do, "do", "do");
    assert.deepEqual(k.Else, "else", "else");
    assert.deepEqual(k.Enum, "enum", "enum");
    assert.deepEqual(k.Export, "export", "export");
    assert.deepEqual(k.Extends, "extends", "extends");
    assert.deepEqual(k.False, "false", "false");
    assert.deepEqual(k.Finally, "finally", "finally");
    assert.deepEqual(k.For, "for", "for");
    assert.deepEqual(k.Function, "function", "function");
    assert.deepEqual(k.If, "if", "if");
    assert.deepEqual(k.Import, "import", "import");
    assert.deepEqual(k.In, "in", "in");
    assert.deepEqual(k.Instanceof, "instanceof", "instanceof");
    assert.deepEqual(k.New, "new", "new");
    assert.deepEqual(k.Null, "null", "null");
    assert.deepEqual(k.Return, "return", "return");
    assert.deepEqual(k.Super, "super", "super");
    assert.deepEqual(k.Switch, "switch", "switch");
    assert.deepEqual(k.This, "this", "this");
    assert.deepEqual(k.Throw, "throw", "throw");
    assert.deepEqual(k.True, "true", "true");
    assert.deepEqual(k.Try, "try", "try");
    assert.deepEqual(k.Typeof, "typeof", "typeof");
    assert.deepEqual(k.Var, "var", "var");
    assert.deepEqual(k.Void, "void", "void");
    assert.deepEqual(k.While, "while", "while");
    assert.deepEqual(k.With, "with", "with");
    assert.deepEqual(k.As, "as", "as");
    assert.deepEqual(k.Implements, "implements", "implements");
    assert.deepEqual(k.Interface, "interface", "interface");
    assert.deepEqual(k.Let, "let", "let");
    assert.deepEqual(k.Package, "package", "package");
    assert.deepEqual(k.Private, "private", "private");
    assert.deepEqual(k.Protected, "protected", "protected");
    assert.deepEqual(k.Public, "public", "public");
    assert.deepEqual(k.Static, "static", "static");
    assert.deepEqual(k.Yield, "yield", "yield");
    assert.deepEqual(k.Any, "any", "any");
    assert.deepEqual(k.Boolean, "boolean", "boolean");
    assert.deepEqual(k.constructor, "constructor", "constructor$ #299");
    assert.deepEqual(k.Constructor$1, "new constructor", "constructor$$1");
    assert.deepEqual(k.Declare, "declare", "declare");
    assert.deepEqual(k.Get, "get", "get");
    assert.deepEqual(k.Module, "module", "module");
    assert.deepEqual(k.Require, "require", "require");
    assert.deepEqual(k.Number, "number", "number");
    assert.deepEqual(k.Set, "set", "set");
    assert.deepEqual(k.String, "string", "string");
    assert.deepEqual(k.Symbol, "symbol", "symbol");
    assert.deepEqual(k.Type, "type", "type");
    assert.deepEqual(k.From, "from", "from");
    assert.deepEqual(k.Of, "of", "of");
});

QUnit.test("Issue #1877", function (assert) {
    //Unseeded
    var r = new System.Random.ctor();

    var ITERATIONS = 100;

    for (var i = 0; i < ITERATIONS; i++) {
        var x = r.Next$1(20);
        assert.ok(x >= 0 && x < 20, x + " under 20 - Next(maxValue)");
    }

    for (var i = 0; i < ITERATIONS; i++) {
        var x = r.Next$2(20, 30);
        assert.ok(x >= 20 && x < 30, x + " between 20 and 30 - Next(minValue, maxValue)");
    }

    for (var i = 0; i < ITERATIONS; i++) {
        var x = r.NextDouble();
        assert.ok(x >= 0.0 && x < 1.0, x + " between 0.0 and 1.0  - NextDouble()");
    }

    //Seeded
    var seed = Date.now();

    var r1 = new System.Random.$ctor1(seed);
    var r2 = new System.Random.$ctor1(seed);

    var b1 = [];
    r1.NextBytes(b1);

    var b2 = [];
    r2.NextBytes(b2);

    for (var i = 0; i < b1.length; i++)
    {
        assert.equal(b1[i], b2[i], "NextBytes()");
    }

    for (var i = 0; i < b1.length; i++)
    {
        var x1 = r1.Next();
        var x2 = r2.Next();

        assert.equal(x1, x2, "Next()");
    }
});

QUnit.test("Issue #1898", function (assert) {
    assert.equal(System.Guid.Empty.toString(), "00000000-0000-0000-0000-000000000000");

    var result = new System.Guid.ctor();
    assert.equal(result.toString(), "00000000-0000-0000-0000-000000000000");

    var g = new System.Guid.$ctor1([ 0x78, 0x95, 0x62, 0xa8, 0x26, 0x7a, 0x45, 0x61, 0x90, 0x32, 0xd9, 0x1a, 0x3d, 0x54, 0xbd, 0x68 ]);
    assert.equal(g.toString(), "a8629578-7a26-6145-9032-d91a3d54bd68", "value");
    assert.throws(() => new System.Guid.$ctor1([ 0x78, 0x95, 0x62, 0xa8, 0x26, 0x7a ]), "Invalid array should throw");

    var g = new System.Guid.$ctor3(0x789562a8, 0x267a, 0x4561, [ 0x90, 0x32, 0xd9, 0x1a, 0x3d, 0x54, 0xbd, 0x68 ]);
    assert.equal(g.toString(), "789562a8-267a-4561-9032-d91a3d54bd68", "value");

    var g = new System.Guid.$ctor5(0x789562a8, 0x267a, 0x4561, 0x90, 0x32, 0xd9, 0x1a, 0x3d, 0x54, 0xbd, 0x68);
    assert.equal(g.toString(), "789562a8-267a-4561-9032-d91a3d54bd68", "value");

    var g = new System.Guid.$ctor2(0x789562a8, 0x267a, 0x4561, 0x90, 0x32, 0xd9, 0x1a, 0x3d, 0x54, 0xbd, 0x68);
    assert.equal(g.toString(), "789562a8-267a-4561-9032-d91a3d54bd68", "value");

    var g1 = new System.Guid.$ctor4("A6993C0A-A8CB-45D9-994B-90E7203E4FC6");
    var g2 = new System.Guid.$ctor4("{A6993C0A-A8CB-45D9-994B-90E7203E4FC6}");
    var g3 = new System.Guid.$ctor4("(A6993C0A-A8CB-45D9-994B-90E7203E4FC6)");
    var g4 = new System.Guid.$ctor4("A6993C0AA8CB45D9994B90E7203E4FC6");

    assert.equal(g1.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g1");
    assert.equal(g2.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g2");
    assert.equal(g3.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g3");
    assert.equal(g4.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g4");
    assert.throws(() => new System.Guid.$ctor4("x"), "Invalid should throw");

    g1 = System.Guid.Parse("A6993C0A-A8CB-45D9-994B-90E7203E4FC6");
    assert.equal(g1.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g1");
    assert.throws(() => System.Guid.Parse("x"), "Invalid should throw");

    g1 = System.Guid.ParseExact("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", "D");
    var g2 = System.Guid.ParseExact("{A6993C0A-A8CB-45D9-994B-90E7203E4FC6}", "B");
    var g3 = System.Guid.ParseExact("(A6993C0A-A8CB-45D9-994B-90E7203E4FC6)", "P");
    var g4 = System.Guid.ParseExact("A6993C0AA8CB45D9994B90E7203E4FC6", "N");

    assert.equal(g1.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g1");
    assert.equal(g2.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g2");
    assert.equal(g3.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g3");
    assert.equal(g4.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g4");
    assert.throws(() => System.Guid.ParseExact("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", "B"), "Invalid B should throw");
    assert.throws(() => System.Guid.ParseExact("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", "P"), "Invalid P should throw");
    assert.throws(() => System.Guid.ParseExact("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", "N"), "Invalid N should throw");
    assert.throws(() => System.Guid.ParseExact("A6993C0AA8CB45D9994B90E7203E4FC6", "D"), "Invalid D should throw");

    var r = { v: new System.Guid.ctor() };
    assert.ok(System.Guid.TryParse("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", r), "g1 result");
    assert.equal(r.v.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g1");
    assert.notOk(System.Guid.TryParse("x", r), "Invalid should throw");
    assert.equal(r.v.toString(), "00000000-0000-0000-0000-000000000000", "g5");

    assert.ok(System.Guid.TryParseExact("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", "D", r), "g1 result");
    assert.equal(r.v.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g1");
    assert.ok(System.Guid.TryParseExact("{A6993C0A-A8CB-45D9-994B-90E7203E4FC6}", "B", r), "g2 result");
    assert.equal(r.v.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g2");
    assert.ok(System.Guid.TryParseExact("(A6993C0A-A8CB-45D9-994B-90E7203E4FC6)", "P", r), "g3 result");
    assert.equal(r.v.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g3");
    assert.ok(System.Guid.TryParseExact("A6993C0AA8CB45D9994B90E7203E4FC6", "N", r), "g4 result");
    assert.equal(r.v.toString(), "a6993c0a-a8cb-45d9-994b-90e7203e4fc6", "g4");
    assert.notOk(System.Guid.TryParseExact("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", "B", r), "g5 result");
    assert.equal(r.v.toString(), "00000000-0000-0000-0000-000000000000", "g5");
    assert.notOk(System.Guid.TryParseExact("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", "P", r), "g6 result");
    assert.equal(r.v.toString(), "00000000-0000-0000-0000-000000000000", "g6");
    assert.notOk(System.Guid.TryParseExact("A6993C0A-A8CB-45D9-994B-90E7203E4FC6", "N", r), "g7 result");
    assert.equal(r.v.toString(), "00000000-0000-0000-0000-000000000000", "g7");
    assert.notOk(System.Guid.TryParseExact("A6993C0AA8CB45D9994B90E7203E4FC6", "D", r), "g8 result");
    assert.equal(r.v.toString(), "00000000-0000-0000-0000-000000000000", "g8");

    g = new System.Guid.$ctor4("F3D8B3C0-88F0-4148-844C-232ED03C153C");
    assert.equal(g.compareTo(new System.Guid.$ctor4("F3D8B3C0-88F0-4148-844C-232ED03C153C")), 0, "equal");
    assert.notEqual(g.compareTo(new System.Guid.$ctor4("E4C221BE-9B39-4398-B82A-48BA4648CAE0")), 0, "not equal");

    var g = new System.Guid.$ctor4("DE33AC65-09CB-465C-AD7E-53124B2104E8");
    assert.equal(g.ToString("N"), "de33ac6509cb465cad7e53124b2104e8", "N");
    assert.equal(g.ToString("D"), "de33ac65-09cb-465c-ad7e-53124b2104e8", "D");
    assert.equal(g.ToString("B"), "{de33ac65-09cb-465c-ad7e-53124b2104e8}", "B");
    assert.equal(g.ToString("P"), "(de33ac65-09cb-465c-ad7e-53124b2104e8)", "P");
    assert.equal(g.ToString(""), "de33ac65-09cb-465c-ad7e-53124b2104e8", "empty");
    assert.equal(g.ToString(null), "de33ac65-09cb-465c-ad7e-53124b2104e8", "null");

    var g = System.Guid.NewGuid();
    var s = g.ToString("N");
    assert.ok(s[16] == '8' || s[16] == '9' || s[16] == 'a' || s[16] == 'b', "Should be standard guid");
    assert.ok(s[12] == '4', "Should be type 4 guid");

    var g = new System.Guid.$ctor4("8440F854-0C0B-4355-9722-1608D62E8F87");
    assert.deepEqual(g.ToByteArray(), [ 0x54, 0xf8, 0x40, 0x84, 0x0b, 0x0c, 0x55, 0x43, 0x97, 0x22, 0x16, 0x08, 0xd6, 0x2e, 0x8f, 0x87 ]);
});
