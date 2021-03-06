System.register(['../util/not', './filter'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var not_1, filter_1;
    /**
     * Splits the source Observable into two, one with values that satisfy a
     * predicate, and another with values that don't satisfy the predicate.
     *
     * <span class="informal">It's like {@link filter}, but returns two Observables:
     * one like the output of {@link filter}, and the other with values that did not
     * pass the condition.</span>
     *
     * <img src="./img/partition.png" width="100%">
     *
     * `partition` outputs an array with two Observables that partition the values
     * from the source Observable through the given `predicate` function. The first
     * Observable in that array emits source values for which the predicate argument
     * returns true. The second Observable emits source values for which the
     * predicate returns false. The first behaves like {@link filter} and the second
     * behaves like {@link filter} with the predicate negated.
     *
     * @example <caption>Partition click events into those on DIV elements and those elsewhere</caption>
     * var clicks = Rx.Observable.fromEvent(document, 'click');
     * var parts = clicks.partition(ev => ev.target.tagName === 'DIV');
     * var clicksOnDivs = parts[0];
     * var clicksElsewhere = parts[1];
     * clicksOnDivs.subscribe(x => console.log('DIV clicked: ', x));
     * clicksElsewhere.subscribe(x => console.log('Other clicked: ', x));
     *
     * @see {@link filter}
     *
     * @param {function(value: T, index: number): boolean} predicate A function that
     * evaluates each value emitted by the source Observable. If it returns `true`,
     * the value is emitted on the first Observable in the returned array, if
     * `false` the value is emitted on the second Observable in the array. The
     * `index` parameter is the number `i` for the i-th source emission that has
     * happened since the subscription, starting from the number `0`.
     * @param {any} [thisArg] An optional argument to determine the value of `this`
     * in the `predicate` function.
     * @return {[Observable<T>, Observable<T>]} An array with two Observables: one
     * with values that passed the predicate, and another with values that did not
     * pass the predicate.
     * @method partition
     * @owner Observable
     */
    function partition(predicate, thisArg) {
        return [
            filter_1.filter.call(this, predicate),
            filter_1.filter.call(this, not_1.not(predicate, thisArg))
        ];
    }
    exports_1("partition", partition);
    return {
        setters:[
            function (not_1_1) {
                not_1 = not_1_1;
            },
            function (filter_1_1) {
                filter_1 = filter_1_1;
            }],
        execute: function() {
        }
    }
});
//# sourceMappingURL=partition.js.map