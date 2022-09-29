const mongoose = require('mongoose');

const Rules = {
    admin: 0,
    client: 1
}

const ActionsDefault = {
    NewOrder: 1,
    ViewOrder: 1,
    EditOrder: 0,
    EditClientAdmin: 0,
    EditClient: 1
}

const userSchema = mongoose.Schema({
    _id: mongoose.Schema.Types.ObjectId,
    name : { type: String, required: true },
    email: {
        type: String, 
        required: true, 
        useCreateIndex: true, 
        match: /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/
    },
    password: { type: String, required: true },
    address: { type: String, required: true },
    role: { type: Number, required: true, default: Rules.client },
    actions: { type: Array, required: true, default: ActionsDefault }
});

module.exports = mongoose.model('User', userSchema);