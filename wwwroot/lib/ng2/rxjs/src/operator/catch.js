System.register(['../OuterSubscriber', '../util/subscribeToResult'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __extends = (this && this.__extends) || function (d, b) {
        for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
    var OuterSubscriber_1, subscribeToResult_1;
    var CatchOperator, CatchSubscriber;
    /**
     * Catches errors on the observable to be handled by returning a new observable or throwing an error.
     * @param {function} selector a function that takes as arguments `err`, which is the error, and `caught`, which
     *  is the source observable, in case you'd like to "retry" that observable by returning it again. Whatever observable
     *  is returned by the `selector` will be used to continue the observable chain.
     * @return {Observable} an observable that originates from either the source or the observable returned by the
     *  catch `selector` function.
     * @method catch
     * @owner Observable
     */
    function _catch(selector) {
        var operator = new CatchOperator(selector);
        var caught = this.lift(operator);
        return (operator.caught = caught);
    }
    exports_1("_catch", _catch);
    return {
        setters:[
            function (OuterSubscriber_1_1) {
                OuterSubscriber_1 = OuterSubscriber_1_1;
            },
            function (subscribeToResult_1_1) {
                subscribeToResult_1 = subscribeToResult_1_1;
            }],
        execute: function() {
            CatchOperator = (function () {
                function CatchOperator(selector) {
                    this.selector = selector;
                }
                CatchOperator.prototype.call = function (subscriber, source) {
                    return source._subscribe(new CatchSubscriber(subscriber, this.selector, this.caught));
                };
                return CatchOperator;
            }());
            /**
             * We need this JSDoc comment for affecting ESDoc.
             * @ignore
             * @extends {Ignored}
             */
            CatchSubscriber = (function (_super) {
                __extends(CatchSubscriber, _super);
                function CatchSubscriber(destination, selector, caught) {
                    _super.call(this, destination);
                    this.selector = selector;
                    this.caught = caught;
                }
                // NOTE: overriding `error` instead of `_error` because we don't want
                // to have this flag this subscriber as `isStopped`.
                CatchSubscriber.prototype.error = function (err) {
                    if (!this.isStopped) {
                        var result = void 0;
                        try {
                            result = this.selector(err, this.caught);
                        }
                        catch (err) {
                            this.destination.error(err);
                            return;
                        }
                        this.unsubscribe();
                        this.destination.remove(this);
                        subscribeToResult_1.subscribeToResult(this, result);
                    }
                };
                return CatchSubscriber;
            }(OuterSubscriber_1.OuterSubscriber));
        }
    }
});
//# sourceMappingURL=catch.js.map