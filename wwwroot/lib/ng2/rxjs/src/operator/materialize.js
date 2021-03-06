System.register(['../Subscriber', '../Notification'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __extends = (this && this.__extends) || function (d, b) {
        for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
    var Subscriber_1, Notification_1;
    var MaterializeOperator, MaterializeSubscriber;
    /**
     * Represents all of the notifications from the source Observable as `next`
     * emissions marked with their original types within {@link Notification}
     * objects.
     *
     * <span class="informal">Wraps `next`, `error` and `complete` emissions in
     * {@link Notification} objects, emitted as `next` on the output Observable.
     * </span>
     *
     * <img src="./img/materialize.png" width="100%">
     *
     * `materialize` returns an Observable that emits a `next` notification for each
     * `next`, `error`, or `complete` emission of the source Observable. When the
     * source Observable emits `complete`, the output Observable will emit `next` as
     * a Notification of type "complete", and then it will emit `complete` as well.
     * When the source Observable emits `error`, the output will emit `next` as a
     * Notification of type "error", and then `complete`.
     *
     * This operator is useful for producing metadata of the source Observable, to
     * be consumed as `next` emissions. Use it in conjunction with
     * {@link dematerialize}.
     *
     * @example <caption>Convert a faulty Observable to an Observable of Notifications</caption>
     * var letters = Rx.Observable.of('a', 'b', 13, 'd');
     * var upperCase = letters.map(x => x.toUpperCase());
     * var materialized = upperCase.materialize();
     * materialized.subscribe(x => console.log(x));
     *
     * @see {@link Notification}
     * @see {@link dematerialize}
     *
     * @return {Observable<Notification<T>>} An Observable that emits
     * {@link Notification} objects that wrap the original emissions from the source
     * Observable with metadata.
     * @method materialize
     * @owner Observable
     */
    function materialize() {
        return this.lift(new MaterializeOperator());
    }
    exports_1("materialize", materialize);
    return {
        setters:[
            function (Subscriber_1_1) {
                Subscriber_1 = Subscriber_1_1;
            },
            function (Notification_1_1) {
                Notification_1 = Notification_1_1;
            }],
        execute: function() {
            MaterializeOperator = (function () {
                function MaterializeOperator() {
                }
                MaterializeOperator.prototype.call = function (subscriber, source) {
                    return source._subscribe(new MaterializeSubscriber(subscriber));
                };
                return MaterializeOperator;
            }());
            /**
             * We need this JSDoc comment for affecting ESDoc.
             * @ignore
             * @extends {Ignored}
             */
            MaterializeSubscriber = (function (_super) {
                __extends(MaterializeSubscriber, _super);
                function MaterializeSubscriber(destination) {
                    _super.call(this, destination);
                }
                MaterializeSubscriber.prototype._next = function (value) {
                    this.destination.next(Notification_1.Notification.createNext(value));
                };
                MaterializeSubscriber.prototype._error = function (err) {
                    var destination = this.destination;
                    destination.next(Notification_1.Notification.createError(err));
                    destination.complete();
                };
                MaterializeSubscriber.prototype._complete = function () {
                    var destination = this.destination;
                    destination.next(Notification_1.Notification.createComplete());
                    destination.complete();
                };
                return MaterializeSubscriber;
            }(Subscriber_1.Subscriber));
        }
    }
});
//# sourceMappingURL=materialize.js.map