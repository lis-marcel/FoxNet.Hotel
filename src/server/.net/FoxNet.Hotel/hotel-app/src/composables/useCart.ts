import { computed, ref } from "vue"

const CartItems = ref<any>([]);

function updateCartValue() {
    var itemsValue: any = 0;

    CartItems._value.forEach((element: any) => {
        var temp = parseFloat(element.price)

        itemsValue += temp;
    });

    itemsValue = itemsValue.toFixed(2);

    return itemsValue;
}

export const useCart = () => {

    const cartItemsCounter = computed(() => CartItems.value.length);

    const addToCart = (product: any) => {
        CartItems.value.push(product);
    };

    const removeFromCart = () => { 
        CartItems.value.pop()
    };

    const cartItemsValue = computed(() => updateCartValue());

    return {
        CartItems,
        addToCart,
        cartItemsCounter,
        cartItemsValue,
        removeFromCart, 
    }
}