System.register(['../Observable'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __extends = (this && this.__extends) || function (d, b) {
        for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
    var Observable_1;
    var PairsObservable;
    function dispatch(state) {
        var obj = state.obj, keys = state.keys, length = state.length, index = state.index, subscriber = state.subscriber;
        if (index === length) {
            subscriber.complete();
            return;
        }
        var key = keys[index];
        subscriber.next([key, obj[key]]);
        state.index = index + 1;
        this.schedule(state);
    }
    return {
        setters:[
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            }],
        execute: function() {
            /**
             * We need this JSDoc comment for affecting ESDoc.
             * @extends {Ignored}
             * @hide true
             */
            PairsObservable = (function (_super) {
                __extends(PairsObservable, _super);
                function PairsObservable(obj, scheduler) {
                    _super.call(this);
                    this.obj = obj;
                    this.scheduler = scheduler;
                    this.keys = Object.keys(obj);
                }
                /**
                 * Convert an object into an observable sequence of [key, value] pairs
                 * using an optional Scheduler to enumerate the object.
                 *
                 * @example <caption>Converts a javascript object to an Observable</caption>
                 * var obj = {
                 *   foo: 42,
                 *   bar: 56,
                 *   baz: 78
                 * };
                 *
                 * var source = Rx.Observable.pairs(obj);
                 *
                 * var subscription = source.subscribe(
                 *   function (x) {
                 *     console.log('Next: %s', x);
                 *   },
                 *   function (err) {
                 *     console.log('Error: %s', err);
                 *   },
                 *   function () {
                 *     console.log('Completed');
                 *   });
                 *
                 * @param {Object} obj The object to inspect and turn into an
                 * Observable sequence.
                 * @param {Scheduler} [scheduler] An optional Scheduler to run the
                 * enumeration of the input sequence on.
                 * @returns {(Observable<Array<string | T>>)} An observable sequence of
                 * [key, value] pairs from the object.
                 */
                PairsObservable.create = function (obj, scheduler) {
                    return new PairsObservable(obj, scheduler);
                };
                PairsObservable.prototype._subscribe = function (subscriber) {
                    var _a = this, keys = _a.keys, scheduler = _a.scheduler;
                    var length = keys.length;
                    if (scheduler) {
                        return scheduler.schedule(dispatch, 0, {
                            obj: this.obj, keys: keys, length: length, index: 0, subscriber: subscriber
                        });
                    }
                    else {
                        for (var idx = 0; idx < length; idx++) {
                            var key = keys[idx];
                            subscriber.next([key, this.obj[key]]);
                        }
                        subscriber.complete();
                    }
                };
                return PairsObservable;
            }(Observable_1.Observable));
            exports_1("PairsObservable", PairsObservable);
        }
    }
});
//# sourceMappingURL=PairsObservable.js.map