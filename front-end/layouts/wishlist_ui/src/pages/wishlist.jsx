import { Component } from 'react';

export default class wishlist extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaDesejos: [],
            idUsuario: 0,
            desejo: ''
        };
    };

    buscarDesejo = () => {
        console.log('Chamada para a API');

        fetch('http://localhost:5000/api/wishlists').then(r => r.json()).then(dados => this.setState({ listaDesejos: dados })).catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.buscarDesejo();
    }

    render() {
        return (
            <div>
                <main>
                    {
                        this.state.listaDesejos.map((wishlist) => {
                            return (
                                <tr key={wishlist.idUsuario}>
                                    <td>{wishlist.desejo}</td>
                                    <td>{wishlist.tituloTipoEvento}</td>
                                </tr>)
                        }
                        )}
                </main>
            </div>
        )
    }

}