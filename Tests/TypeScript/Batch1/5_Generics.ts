﻿/// <reference path="..\..\Runner\resources\qunit\qunit.d.ts" />
/// <reference path="..\..\Runner\TypeScript\App1\bridge.d.ts" />
/// <reference path="..\..\Runner\TypeScript\App1\Generics.d.ts" />

"use strict";

QUnit.module("TypeScript - Generics");
QUnit.test("Check predefined generic instances", function (assert) {
    var g1 = Generics.implementation.SimpleGenericInt;
    assert.deepEqual(g1.GetSomething(5), 5, "simpleGenericInt");

    var g2 = Generics.implementation.SimpleDoubleGenericIntString;
    assert.deepEqual(g2.GetSomething(5), 5, "simpleDoubleGenericIntString - int");
    assert.deepEqual(g2.GetSomethingMore("25"), "25", "simpleDoubleGenericIntString - string");

    var g3 = Generics.implementation.GenericINamedEntity;
    var i3 = new Generics.NamedEntity();
    i3.Name$1 = "Dove";
    var r3 = g3.GetSomething(i3);
    assert.deepEqual(r3, i3, "genericINamedEntity");
    assert.deepEqual(r3 instanceof Generics.INamedEntity, true, "genericINamedEntity instance of INameEntity");
    assert.deepEqual(r3 instanceof Generics.NamedEntity, true, "genericINamedEntity instance of NameEntity");

    var g4 = Generics.implementation.GenericNamedEntity;
    var i4 = new Generics.NamedEntity();
    i4.Name$1 = "Eagle";
    var r4 = g4.GetSomething(i4);
    assert.deepEqual(r4, i4, "genericNamedEntity");
    assert.deepEqual(r4 instanceof Generics.INamedEntity, true, "genericNamedEntity instance of INameEntity");
    assert.deepEqual(r4 instanceof Generics.NamedEntity, true, "genericNamedEntity instance of NameEntity");

    var g5 = Generics.implementation.GenericClassObject;
    var i5: any = "class object";
    var r5 = g5.GetSomething(i5);
    assert.deepEqual(r5, i5, "genericClassObject");
    // TODO #296
    //assert.deepEqual(r5 instanceof Object, true, "genericClassObject instance of Object");

    var g6 = Generics.implementation.GenericClassNamedEntity;
    var i6 = new Generics.NamedEntity();
    i6.Name$1 = "Penguin";
    var r6 = g6.GetSomething(i6);
    assert.deepEqual(r6, i6, "genericClassNamedEntity");
    assert.deepEqual(r6 instanceof Generics.INamedEntity, true, "genericClassNamedEntity instance of INameEntity");
    assert.deepEqual(r6 instanceof Generics.NamedEntity, true, "genericClassNamedEntity instance of NameEntity");

    var g7 = Generics.implementation.GenericNew;
    var i7 = new Generics.NewClass();
    i7.Data = 700;
    var r7 = g7.GetSomething(i7);
    assert.deepEqual(r7, i7, "genericNew");
    assert.deepEqual(r7 instanceof Generics.NewClass, true, "genericNew instance of NewClass");

    var g8 = Generics.implementation.GenericNewAndClass;
    var i8 = new Generics.NewClass();
    i8.Data = 800;
    var r8 = g8.GetSomething(i8);
    assert.deepEqual(r8, i8, "genericNewAndClass");
    assert.deepEqual(r8 instanceof Generics.NewClass, true, "genericNewAndClass instance of NewClass");
});

QUnit.test("Create generic instances", function (assert) {
    var name = "My name is Named Entity";
    var namedEntity = new Generics.NamedEntity();
    namedEntity.Name$1 = name;

    var c10 = new (Generics.SimpleGeneric$1(Number))(5);
    assert.deepEqual(c10.GetSomething(7), 7, "simpleGeneric$1(Number) getSomething");
    assert.deepEqual(c10.Instance, 5, "simpleGeneric$1(Number) instance");

    var c11 = new (Generics.SimpleGeneric$1(Generics.NamedEntity))(namedEntity);
    assert.deepEqual((c11.GetSomething(namedEntity) as Generics.NamedEntity).Name$1, name, "SimpleGeneric$1(Generics.NamedEntity) getSomething");
    assert.deepEqual(c11.Instance, namedEntity, "SimpleGeneric$1(Generics.NamedEntity) instance");

    var c20 = new (Generics.SimpleDoubleGeneric$2(Object, Number).$ctor1)("I'm object", 35);
    assert.deepEqual(c20.GetSomething(5), 5, "SimpleDoubleGeneric$2(Object, Number) getSomething");
    assert.deepEqual(c20.GetSomethingMore(25), 25, "SimpleDoubleGeneric$2(Object, Number) getSomethingMore");
    assert.deepEqual(c20.InstanceT, "I'm object", "SimpleDoubleGeneric$2(Object, Number) instanceT");
    assert.deepEqual(c20.InstanceK, 35, "SimpleDoubleGeneric$2(Object, Number) instanceK");

    var c21 = new (Generics.SimpleDoubleGeneric$2(Object, Number).ctor)();
    assert.deepEqual(c21.GetSomething(7), 7, "SimpleDoubleGeneric$2(Object, Number) parameterless constructor getSomething");
    assert.deepEqual(c21.GetSomethingMore(35), 35, "SimpleDoubleGeneric$2(Object, Number) parameterless constructor getSomethingMore");
    assert.deepEqual(c21.InstanceT, null, "SimpleDoubleGeneric$2(Object, Number) instanceT");
    assert.deepEqual(c21.InstanceK, 0, "SimpleDoubleGeneric$2(Object, Number) instanceK");

    var c30 = new (Generics.GenericINamedEntity$1(Generics.NamedEntity))(namedEntity);
    assert.deepEqual((c30.GetSomething(namedEntity) as Generics.NamedEntity).Name$1, name, "GenericINamedEntity$1(Generics.NamedEntity) getSomething");
    assert.deepEqual(c30.Instance, namedEntity, "GenericINamedEntity$1(Generics.NamedEntity) instance");

    var c40 = new (Generics.GenericNamedEntity$1(Generics.NamedEntity))(namedEntity);
    assert.deepEqual((c40.GetSomething(namedEntity) as Generics.NamedEntity).Name$1, name, "GenericNamedEntity$1(Generics.NamedEntity) getSomething");
    assert.deepEqual(c40.Instance, namedEntity, "GenericNamedEntity$1(Generics.NamedEntity) instance");

    var c50 = new (Generics.GenericClass$1(Generics.NamedEntity))(namedEntity);
    assert.deepEqual((c50.GetSomething(namedEntity) as Generics.NamedEntity).Name$1, name, "GenericClass$1(Generics.NamedEntity) getSomething");
    assert.deepEqual(c50.Instance, namedEntity, "GenericClass$1(Generics.NamedEntity) instance");
    var c51 = new (Generics.GenericClass$1(String))("Trest");
    assert.deepEqual(c51.GetSomething("Just string"), "Just string", "GenericClass$1(String) getSomething");
    assert.deepEqual(c51.Instance, "Trest", "GenericClass$1(String) instance");

    var c60 = new (Generics.GenericStruct$1(Generics.NamedEntity))(namedEntity);
    assert.deepEqual((c60.GetSomething(namedEntity) as Generics.NamedEntity).Name$1, name, "GenericStruct$1(Generics.NamedEntity) getSomething");
    assert.deepEqual(c60.Instance, namedEntity, "GenericStruct$1(Generics.NamedEntity) instance");
    var c61 = new (Generics.GenericStruct$1(String))("Trest");
    assert.deepEqual(c61.GetSomething("Just string"), "Just string", "GenericStruct$1(String) getSomething");
    assert.deepEqual(c61.Instance, "Trest", "GenericStruct$1(String) instance");

    var c70 = new (Generics.GenericNew$1(String))("New trest");
    assert.deepEqual(c70.GetSomething("Just string"), "Just string", "GenericNew$1(String) getSomething");
    assert.deepEqual(c70.Instance, "New trest", "GenericNew$1(String) instance");
    var c71 = new (Generics.GenericNew$1(Object))("New trest");
    assert.deepEqual(c71.GetSomething("Just string"), "Just string", "GenericNew$1(Object) getSomething");
    assert.deepEqual(c71.Instance, "New trest", "GenericNew$1(Object) instance");

    var c80 = new (Generics.GenericNewAndClass$1(String))("New trest80");
    assert.deepEqual(c80.GetSomething("Just string80"), "Just string80", "GenericNewAndClass$1(String) getSomething");
    assert.deepEqual(c80.Instance, "New trest80", "GenericNewAndClass$1(String) instance");
    var c81 = new (Generics.GenericNewAndClass$1(Object))("New trest81");
    assert.deepEqual(c81.GetSomething("Just string81"), "Just string81", "GenericNewAndClass$1(Object) getSomething");
    assert.deepEqual(c81.Instance, "New trest81", "GenericNewAndClass$1(Object) instance");
});
