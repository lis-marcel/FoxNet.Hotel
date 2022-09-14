import { computed, ref } from "vue"

const CartItems = ref<any>([]);

function getItemsValues(CartItems: any) {
    var itemsValue = 0;

    CartItems._value.forEach((element: any) => {
        itemsValue += element.price
    });

    return itemsValue;
}

export const useCart = () => {

    const cartItemsCounter = computed(() => CartItems.value.length);
    const addToCart = (product: any) => {
        CartItems.value.push(product);
    };
    const removeFromCart = () => CartItems.value.pop();
    const cartItemsValue = getItemsValues(CartItems);
    

    return {
        CartItems,
        addToCart,
        cartItemsCounter,
        cartItemsValue,
        removeFromCart, 
    }
}