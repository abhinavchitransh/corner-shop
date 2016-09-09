shared_examples('basket') do |shopkeeper|

  describe('basket') do

    example('is initially empty') do
      shopkeeper.open do |shop|
        expect(shop.send('b')).to eq(['Your basket is empty'])
      end
    end

    example('lists items added') do
      shopkeeper.open do |shop|
        expect(shop.send('a 1045')).to be_empty
        expect(shop.send('b')[0]).to include('1.20     1x     Finest brie, 100g')
        expect(shop.send('b')[2]).to include('1.20 total')
      end
    end

    example('allows multiple items to be added at once') do
      shopkeeper.open do |shop|
        shop.send('a 6000 5')
        expect(shop.send('b')[0]).to include('3.99     5x     Phillips screwdriver, small, with co...')
        expect(shop.send('b')[2]).to include('19.95 total')
      end
    end

    example('applies a 10% discount over £20') do
      shopkeeper.open do |shop|
        shop.send('a 6000 6')
        expect(shop.send('b')[1]).to include('10% discount')
        expect(shop.send('b')[3]).to include('21.55 total')
      end
    end

  end

end
